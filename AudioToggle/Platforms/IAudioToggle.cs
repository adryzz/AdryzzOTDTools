using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioToggle
{
    public interface IAudioToggle : IDisposable
    {
        bool Initialized { get; set; }
        bool Initialize();

        void ToggleOutputDevice(int index);
        void ToggleInputDevice(int index);

        void SetDefaultOutputDevice(int index);

        void SetDefaultInputDevice(int index);

        void ListDevices();

        bool Disposed { get; set; }
    }
}
