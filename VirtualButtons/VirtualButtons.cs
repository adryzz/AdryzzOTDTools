using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace VirtualButtons
{
    public class VirtualButtons : IPositionedPipelineElement<IDeviceReport>
    {
        public PipelinePosition Position => PipelinePosition.Raw;

        public event Action<IDeviceReport> Emit;

        List<VirtualButton> Buttons;

        public void Consume(IDeviceReport value)
        {
            if (Buttons == null)
            {
                Task.Run(InitializeAsync);
            }
            else
            {
                if (value is ITabletReport r)
                {
                    
                }
                else if (value is ITouchReport r)
                {
                    
                }
            }
            Emit?.Invoke(value);
        }

        public async Task InitializeAsync()
        {
            if (File.Exists(ButtonsConfig))
            {
                string lines = await File.ReadAllTextAsync(ButtonsConfig);
            }
            else
            {
                //lol
            }
        }

        [Property("Buttons configuration file")]
        public string ButtonsConfig { get; set; }

        [Property("Triggered by pen"), DefaultPropertyValue(true)]
        public bool IsTriggerableByPen { get; set; }

        [Property("Triggered by touch"), DefaultPropertyValue(true)]
        public bool IsTriggerableByTouch { get; set; }
    }
}
