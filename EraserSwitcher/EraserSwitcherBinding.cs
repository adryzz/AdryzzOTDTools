using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EraserSwitcher
{
    [PluginName("Eraser Switcher")]
    class EraserSwitcherBinding : IBinding
    {
        public void Press(IDeviceReport report)
        {
            EraserSwitcher.EraserState = !EraserSwitcher.EraserState;
        }

        public void Release(IDeviceReport report)
        {
            
        }
    }
}
