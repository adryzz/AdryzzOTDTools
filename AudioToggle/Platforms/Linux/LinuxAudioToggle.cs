using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenTabletDriver.Plugin;

namespace AudioToggle.Platforms.Linux
{
    class LinuxAudioToggle : IAudioToggle
    {
        public bool Initialized { get; set; }
        public bool Disposed { get; set; }


        public void Dispose()
        {
            Disposed = true;
        }

        public bool Initialize()
        {
            Initialized = true;
            return true;
        }

        public void ListDevices()
        {
            throw new NotImplementedException();
        }

        public void ToggleOutputDevice(int index)
        {
            Log.Write("AudioToggle", "Toggle output Device" + index, LogLevel.Debug);
            if (index < 0)
            {
                string output = ShellHelper.Bash("amixer sget 'Master'");
                Log.Write("Plugin", output, LogLevel.Debug);
                if (output.Contains("[on]"))
                {
                    ShellHelper.Bash("amixer sset 'Master' off");
                }
                else
                {
                    ShellHelper.Bash("amixer sset 'Master' on");
                }
            }
        }

        public void ToggleInputDevice(int index)
        {
            Log.Write("Plugin", "Toggle input Device" + index, LogLevel.Debug);
            if (index < 0)
            {
                string output = ShellHelper.Bash("amixer sget 'Capture'");
                Log.Write("Plugin", output, LogLevel.Debug);
                if (output.Contains("[on]"))
                {
                    ShellHelper.Bash("amixer sset 'Capture' off");
                }
                else
                {
                    ShellHelper.Bash("amixer sset 'Capture' on");
                }
            }
        }

        public void SetDefaultOutputDevice(int index)
        {
            
        }

        public void SetDefaultInputDevice(int index)
        {
            
        }
    }
}
