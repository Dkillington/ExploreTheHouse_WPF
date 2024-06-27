using System.Windows;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Automation.Peers;
using System.Diagnostics;
using WPFTutorial.Items;
using NAudio.Mixer;


namespace WPFTutorial
{
    public partial class MainWindow : Window
    {
        public Dictionary<AreaEnum, Area> allAreas = new Dictionary<AreaEnum, Area>();
        public Dictionary<SoundEnums, Sound> allSounds = new Dictionary<SoundEnums, Sound>();
        public Dictionary<StorageEnums, Storage> allStorage = new Dictionary<StorageEnums, Storage>();
        public Dictionary<ItemEnums, Item> allItems = new Dictionary<ItemEnums, Item>();

        private List<Sound> activeSounds = new List<Sound>();

        private Area currentArea = null;
        public MainWindow()
        {
            InitializeComponent();

            // Populate Game
            InitalizeItems();
            InitalizeContainers();
            InitalizeSounds();
            InitalizeAreas();

            ChangeArea(AreaEnum.front); // Establish player at front of house to start

            // Add all items to the game
            void InitalizeItems()
            {
                // Keys
                CreateKey(ItemEnums.atticKey, "Attic Key", "A Dusty Key");

                // Notes
                CreateNote(ItemEnums.bobNote, "Bob's Note", "A note for bob!", "Hi there bob");

                void CreateKey(ItemEnums itemEnum, string name, string description)
                {
                    allItems.Add(itemEnum, new Key(itemEnum, name, description));
                }
                void CreateNote(ItemEnums itemEnum, string name, string description, string text)
                {
                    allItems.Add(itemEnum, new Note(itemEnum, name, description, text));
                }
            }
            // Add all containers to the game
            void InitalizeContainers()
            {
                allStorage.Add(StorageEnums.inventory, new Storage("Inventory", new List<ItemEnums> { }));
                allStorage.Add(StorageEnums.bedroomDrawer, new Storage("Bedroom Drawer", new List<ItemEnums> { ItemEnums.atticKey }));
            }
            // Add all sounds to the game
            void InitalizeSounds()
            {
                foreach(SoundEnums value in Enum.GetValues(typeof(SoundEnums)))
                {
                    if(value != SoundEnums.none)
                    {
                        allSounds.Add(value, new Sound(value));
                    }
                }
            }
            // Add all areas to the game
            void InitalizeAreas()
            {
                NewArea(AreaEnum.front, new List<Button> { frontDoorBtn, exitBtn }, new List<SoundEnums> { SoundEnums.coldWind, SoundEnums.creepyWind, SoundEnums.thunder}); // Front of the house
                NewArea(AreaEnum.hall, new List<Button> { leaveBtn, bedroomBtn, kitchenBtn, atticBtn }, new List<SoundEnums> { SoundEnums.creepyInside}); // Main hallway of house
                NewArea(AreaEnum.bedroom, new List<Button> { leaveBedroomBtn, underbedBtn, sideTableBtn }, new List<SoundEnums> { }); // Master bedroom of the house
                NewArea(AreaEnum.table, new List<Button> { leaveTableBtn, grabNoteBtn }, new List<SoundEnums> { }); // Bedroom Side Table
                NewArea(AreaEnum.underbed, new List<Button> { leaveUnderbedBtn, boxBtn }, new List<SoundEnums> { }); // Under Bed In Bedroom
                NewArea(AreaEnum.kitchen, new List<Button> { leaveKitchenBtn }, new List<SoundEnums> { }); // Kitchen
                NewArea(AreaEnum.attic, new List<Button> { leaveAtticBtn  }, new List<SoundEnums> { }); // Attic
                NewArea(AreaEnum.basement, new List<Button> { leaveBasementBtn  }, new List<SoundEnums> { }); // Basement

                // Function used to simplify the area creation process
                void NewArea(AreaEnum area, List<Button> activeButtons, List<SoundEnums> activeSounds)
                {
                    allAreas.Add(area, new Area(area, activeButtons, activeSounds));
                }
            }
        }

        // Switch to a different room/area (Provide area to switch to, and any entry sounds additional to the area sounds)
        void ChangeArea(AreaEnum area, SoundEnums entrySoundEnum = SoundEnums.none)
        {
            StopAllSounds(); // End all active sounds
            CloseInventory(); // Make sure inventory is closed

            // Recieve all data for the selected room
            currentArea = allAreas[area];

            ChangeScene(currentArea.imgName.ToString()); // Change Background Image
            ShowButtons(currentArea.buttons); // Only show buttons relevant to the area
            ActivateSounds(currentArea.sounds); // Only activate sounds relevant to the area

            // Make sure inventory is closed if a room is changed
            void CloseInventory()
            {
                if (inv.Visibility == Visibility.Visible)
                {
                    inv.ToggleInventory();
                }
            }

            // Stop all current sounds
            void StopAllSounds()
            {
                StopEachSound();
                ClearList();

                // Go through each index of the activeSounds list and fully cancel/dispose of the sound object
                void StopEachSound()
                {
                    foreach (Sound sound in activeSounds)
                    {
                        sound.Stop();
                    }
                }

                // Clear all entries in the activeSounds list
                void ClearList()
                {
                    activeSounds.Clear();
                }
            }

            // Change the current scene
            void ChangeScene(string picPath)
            {
                Debug.WriteLine($"Grabbing background image '{picPath}'");
                try
                {
                    screenImg.Source = new BitmapImage(new Uri($"backgrounds/{picPath}.jpg", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to map image, '{ex}'");
                }
            }

            void ShowButtons(List<Button> _activeButtons)
            {
                // Get all buttons in the MainGrid
                var buttons = MainGrid.Children.OfType<Button>();

                // Hide all buttons
                foreach (var button in buttons)
                {
                    button.Visibility = Visibility.Hidden;
                }

                // Show only the specified buttons
                foreach (var button in _activeButtons)
                {
                    button.Visibility = Visibility.Visible;
                }
            }

            void ActivateSounds(List<SoundEnums> areaSounds)
            {
                // Add Sounds
                AddAreaSounds();
                AddEntrySounds();

                // Play Sounds
                PlaySounds();



                // Add only sounds associated with the area (Rain, wind, etc)
                void AddAreaSounds()
                {
                    foreach (SoundEnums soundEnum in areaSounds)
                    {
                        Sound sound = allSounds[soundEnum]; // Grab the actual Sound object
                        AddToList(sound); // Add it to the list of all active sounds
                    }
                }
                // Add only sounds associated with entry (A door squeak, metal door opening, etc)
                void AddEntrySounds()
                {
                    if (entrySoundEnum != SoundEnums.none)
                    {
                        Sound sound = allSounds[entrySoundEnum]; // Grab the actual Sound object
                        sound.repeats = false; // Set repeating to false (It is supposed to be an entry sound only)
                        activeSounds.Add(sound); // Add it to the list of all active sounds
                    }
                }

                // Add the individual sound to the list of active sounds
                void AddToList(Sound sound)
                {
                    activeSounds.Add(sound);
                }

                // Play all sounds
                void PlaySounds()
                {
                    foreach(Sound sound in activeSounds)
                    {
                        sound.Play();
                    }
                }
            }
        }

        // Send an enum here to loot it
        bool HaveItem(ItemEnums item)
        {
            if (allStorage[StorageEnums.inventory].items.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Loot a storage container
        void Loot(StorageEnums storageEnum)
        {
            lootPanel.LootThis(storageEnum);
        }








        // [Area Buttons]
        // Front of house
        private void frontDoorBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall, SoundEnums.doorslam);
            Loot(StorageEnums.bedroomDrawer);
        }
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Hallway
        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.front);
        }
        private void kitchenBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.kitchen);
        }
        private void bedroomBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.bedroom);
        }
        private void atticBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HaveItem(ItemEnums.atticKey))
            {
                ChangeArea(AreaEnum.attic);
            }
            else
            {
                MessageBox.Show("You need key!");
            }
        }

        // Bedroom
        private void leaveBedroomBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall, SoundEnums.doorslam);
        }
        private void sideTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.table);
        }
        private void leaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.bedroom);
        }
        private void grabNoteBtn_Click(object sender, RoutedEventArgs e)
        {
        }
        private void leaveUnderbedBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.bedroom);
        }
        private void boxBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have found a key to a drawer!", "Key Found!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void underbedBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.underbed);
        }


        // Kitchen
        private void leaveKitchenBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall);
        }

        // Attic
        private void leaveAtticBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall);
        }

        // Basement
        private void leaveBasementBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }


        // Lab
    }

}