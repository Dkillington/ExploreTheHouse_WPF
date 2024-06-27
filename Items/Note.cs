﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.Items
{
    public class Note : Item
    {
        public string text;
        public Note(ItemEnums itemEnum, string name, string description, string _text) : base(itemEnum, name, description)
        {
            text = _text;
        }
    }
}
