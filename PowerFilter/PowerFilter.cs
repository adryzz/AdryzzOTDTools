using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;

namespace PowerFilter
{
    [PluginName("PowerFilter")]
    public class PowerFilter : IPositionedPipelineElement<IDeviceReport>
    {
        public PipelinePosition Position => PipelinePosition.PostTransform;

        public event Action<IDeviceReport> Emit;

        public PowerFilter()
        {
        }

        public void Consume(IDeviceReport value)
        {
            if (value is ITabletReport report)
            {
                if (Info.Driver.OutputMode is AbsoluteOutputMode abs)
                {
                    float x = applyScale(report.Position.X, PowerX, abs.Output.Width);
                    float y = applyScale(report.Position.Y, PowerY, abs.Output.Height);
                    report.Position = new System.Numerics.Vector2(x, y);
                    value = report;
                }
            }
            Emit?.Invoke(value);
        }

        float map(float x, float in_min, float in_max, float out_min, float out_max)
        {
            return (float)(x - in_min) * (out_max - out_min) / (float)(in_max - in_min) + out_min;
        }

        float applyScale(float value, float pow, float displayArea)
        {
            float v = value - value / 2;
            float p = (float)Math.Pow(v, pow);
            if (v < 0)
            {
                p = -p;
            }
            float bounds = displayArea / 2;
            float startBounds = bounds * bounds;
            return map(p, -startBounds, startBounds, -bounds, bounds);
        }

        [SliderProperty("Power X", 0.125f, 2, 1)]
        public float PowerX { get; set; }

        [SliderProperty("Power Y", 0.125f, 2, 1)]
        public float PowerY { get; set; }
    }
}
