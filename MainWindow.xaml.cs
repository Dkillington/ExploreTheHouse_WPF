using System.Windows;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Automation.Peers;


namespace WPFTutorial
{
    public partial class MainWindow : Window
    {
        private Dictionary<AreaEnum, Area> allAreas = new Dictionary<AreaEnum, Area>();
        private Dictionary<SoundEnums, Sound> allSounds = new Dictionary<SoundEnums, Sound>();

        private List<Sound> currentSounds = new List<Sound>();
        private Area currentArea = null;
        private bool keyFound = false;
        public MainWindow()
        {
            InitializeComponent();
            InitalizeSounds();
            InitalizeAreas();
            ChangeArea(AreaEnum.front); // Establish player at front of house to start




            void InitalizeSounds()
            {
                NewSound(SoundEnums.rumble, true);
                NewSound(SoundEnums.gong, true);

                // Function used to simplify the sound creation process
                void NewSound(SoundEnums _soundEnum, bool _repeats)
                {
                    allSounds.Add(_soundEnum, new Sound(_soundEnum, _repeats));
                }
            }
            void InitalizeAreas()
            {
                NewArea(AreaEnum.front, new Button[] { frontDoorBtn, exitBtn }, new Sound[] { allSounds[SoundEnums.rumble] }); // Front of the house
                NewArea(AreaEnum.hall, new Button[] { leaveBtn, bedroomBtn, kitchenBtn }, new Sound[] { allSounds[SoundEnums.gong] }); // Main hallway of house
                NewArea(AreaEnum.bedroom, new Button[] { leaveBedroomBtn, underbedBtn, sideTableBtn }, new Sound[] { }); // Master bedroom of the house
                NewArea(AreaEnum.table, new Button[] { leaveTableBtn, grabNoteBtn }, new Sound[] { }); // Bedroom Side Table
                NewArea(AreaEnum.underbed, new Button[] { leaveUnderbedBtn, boxBtn }, new Sound[] { }); // Under Bed In Bedroom
                NewArea(AreaEnum.kitchen, new Button[] { leaveKitchenBtn }, new Sound[] { }); // Kitchen


                // Function used to simplify the area creation process
                void NewArea(AreaEnum area, Button[] activeButtons, Sound[] activeSounds)
                {
                    allAreas.Add(area, new Area(area, activeButtons, activeSounds));
                }
            }
        }


        void ChangeArea(AreaEnum area, Sound[] soundsStrictlyForEntry = null)
        {
            if (currentArea != null)
            {
                // Stop sounds
                foreach (Sound sound in currentArea.activeSounds)
                {
                    sound.Stop();
                }
            }

            // Recieve all data for the selected room
            currentArea = allAreas[area];

            ChangeScene(currentArea.imgName.ToString()); // Change Background Image
            ShowButtons(currentArea.activeButtons); // Only show buttons relevant to the area
            ActivateSounds(currentArea.activeSounds); // Only activate sounds relevant to the area





            void ChangeScene(string picPath)
            {
                try
                {
                    screenImg.Source = new BitmapImage(new Uri($"pics/{picPath}.jpg", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    
                }
            }

            void ShowButtons(Button[] _activeButtons)
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

            void ActivateSounds(Sound[] _activeSounds )
            {
                foreach(Sound sound in _activeSounds)
                {
                    sound.Play();
                }

                if(soundsStrictlyForEntry != null)
                {
                    foreach (Sound sound in soundsStrictlyForEntry)
                    {
                        sound.repeats = false;
                        sound.Play();
                    }
                }
            }
        }
        private void frontDoorBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall, new Sound[] { allSounds[SoundEnums.rumble] });
        }

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

        private void leaveKitchenBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall);
        }

        private void leaveBedroomBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.hall);
        }

        private void sideTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (keyFound)
            {
                ChangeArea(AreaEnum.table);
            }
            else
            {
                MessageBox.Show("The drawer is locked, You need a key!", "Locked!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void leaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.bedroom);
        }

        private void grabNoteBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Note: \"Hi emma, you suck\n-Reginald\"", "Note From Reginald", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void leaveUnderbedBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.bedroom);
        }
        private void boxBtn_Click(object sender, RoutedEventArgs e)
        {
            if(keyFound)
            {

            }
            else
            {
                MessageBox.Show("You have found a key to a drawer!", "Key Found!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                keyFound = true;
            }
        }

        private void underbedBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeArea(AreaEnum.underbed);
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }

    public class Area
    {
        public AreaEnum imgName;
        public Button[] activeButtons;
        public Sound[] activeSounds;

        public Area(AreaEnum _imgName, Button[] _activeDoors, Sound[] _activeSounds)
        {
            imgName = _imgName;
            activeButtons = _activeDoors;
            activeSounds = _activeSounds;
        }
    }

    public enum AreaEnum
    {
        front,
        hall,
        bedroom,
        kitchen,
        table,
        underbed,
    }
}