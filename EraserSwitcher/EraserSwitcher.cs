using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;

namespace OTDTestFilter
{
    [PluginName("Eraser Switcher Filter")]
    class EraserSwitcher : IPositionedPipelineElement<IDeviceReport>
    {
        public PipelinePosition Position => PipelinePosition.Raw;

        public event Action<IDeviceReport> Emit;

        public static bool EraserState = false;

        public void Consume(IDeviceReport value)
        {
            if (value is ITabletReport report)
            {
                value = new EraserSwitcherReport(report, EraserState);
            }
            Emit?.Invoke(value);
        }
    }
}
