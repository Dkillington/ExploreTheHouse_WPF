using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.Items
{
    public class Item
    {
        public ItemEnums itemEnum;
        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        public string description;


        public Item(ItemEnums _itemEnum, string _name, string _description)
        {
            itemEnum = _itemEnum;
            name = _name;
            description = _description;
        }
    }

    public enum ItemEnums
    {
        atticKey,
        bobNote,
    }
}
