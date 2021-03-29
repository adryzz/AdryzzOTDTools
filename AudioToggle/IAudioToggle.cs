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

        string ListDevices();

        bool Disposed { get; set; }
    }
}
