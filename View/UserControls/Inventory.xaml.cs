using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFTutorial.Items;

namespace WPFTutorial.View.UserControls
{
    public partial class Inventory : UserControl
    {
        public List<Item> containedItems = new List<Item>();
        public Inventory()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleInventory();
        }

        public void ToggleInventory()
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this); // Access window and its elements

            // Toggle inventory
            if (mainWindow != null)
            {
                // Toggle the visibility of the inventory window
                if (mainWindow.inv.Visibility == Visibility.Hidden)
                {
                    OpenInventory();
                }
                else
                {
                    CloseInventory();
                }
            }



            void OpenInventory()
            {
                PopulateInventoryData(); // Fill the inventory's data
                PopulateInventoryVisualList(); // Fill the inventory's list that shows each item

                ShowInventory(); // Show inventory

                void PopulateInventoryData()
                {
                    foreach (ItemEnums itemEnum in mainWindow.allStorage[StorageEnums.inventory].items)
                    {
                        Item item = mainWindow.allItems[itemEnum]; // Grab the item itself
                        mainWindow.inv.containedItems.Add(item); // Add the itemEnum (ID) and item (Actual Item) pair to the inventory data
                    }
                }
                void PopulateInventoryVisualList()
                {
                    foreach(Item item in containedItems)
                    {
                        storageView.Items.Add(item.Name);
                    }
                }
                void ShowInventory()
                {
                    mainWindow.inv.Visibility = Visibility.Visible;
                }
            }

            void CloseInventory()
            {
                Visibility = Visibility.Hidden; // Hide inventory
                storageView.Items.Clear(); // Clear visible list
                containedItems.Clear(); // Clear all inventory data
            }
        }
    }
}
