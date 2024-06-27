using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFTutorial
{
    // Different locations in game (With unique background, buttons to press, and sounds)
    public class Area
    {
        public AreaEnum imgName;
        public List<Button> buttons;
        public List<SoundEnums> sounds;

        public Area(AreaEnum _imgName, List<Button> _areaButtons, List<SoundEnums> _areaSounds)
        {
            imgName = _imgName;
            buttons = _areaButtons;
            sounds = _areaSounds;
        }
    }

    // When you add a picture file to 'pics', make sure it is a jpg and spelled exactly like you put it here
    public enum AreaEnum
    {
        front,
        hall,
        bedroom,
        kitchen,
        table,
        underbed,
        attic,

        // Unused
        basement,
        lab,
    }
}
