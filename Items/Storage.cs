using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.View.UserControls;

namespace WPFTutorial.Items
{
    public class Storage
    {
        public string name;
        public List<ItemEnums> items = new List<ItemEnums>();

        public Storage(string _name, List<ItemEnums> startingItems)
        {
            name = _name;
            items = startingItems;
        }
    }

    public enum StorageEnums
    {
        none, // For NULL
        inventory,
        bedroomDrawer,
    }
}
