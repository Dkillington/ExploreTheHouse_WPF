using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.Items;

namespace WPFTutorial
{
    internal class PlaceHolder
    {
        /*



        public partial class LootPanel
        {
            public ObservableCollection<Item> storedItems { get; set; } = new ObservableCollection<Item>();
            public ObservableCollection<Item> inventoryItems { get; set; } = new ObservableCollection<Item>();

            public StorageEnums openedStorageEnum { get; set; }

            public LootPanel()
            {
                InitializeComponent();
                DataContext = this;
            }

            private void exitBtn_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }

            private void swapToInventoryBtn_Click(object sender, RoutedEventArgs e)
            {
                if (storageView.SelectedItem is Item pickedItem)
                {
                    storedItems.Remove(pickedItem);
                    inventoryItems.Add(pickedItem);
                }
            }

            private void swapToStorageBtn_Click(object sender, RoutedEventArgs e)
            {
                if (inventoryView.SelectedItem is Item pickedItem)
                {
                    inventoryItems.Remove(pickedItem);
                    storedItems.Add(pickedItem);
                }
            }

            public void Close()
            {
                // Get reference to MainWindow
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

                // Update the inventory list in MainWindow
                if (mainWindow != null)
                {
                    mainWindow.UpdateInventory(openedStorageEnum, storedItems.ToList<Item>(), inventoryItems.ToList<Item>());

                    ClearPanelData();
                }

                Visibility = Visibility.Hidden; // Hide Panel

                void ClearPanelData()
                {
                    storedItems.Clear();
                    inventoryItems.Clear();
                }
            }
        }
        */
    }
}
