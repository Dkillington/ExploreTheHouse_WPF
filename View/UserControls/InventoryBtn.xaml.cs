using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public partial class InventoryBtn : UserControl
    {
        public InventoryBtn()
        {
            InitializeComponent();
        }

        private void inventoryBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this); // Access window and its elements

            // Toggle inventory
            if (mainWindow != null)
            {
                mainWindow.inv.ToggleInventory();
            }
        }
    }
}
