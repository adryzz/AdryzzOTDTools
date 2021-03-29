using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AudioToggle
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

        public string ListDevices()
        {
            throw new NotImplementedException();
        }

        public void ToggleOutputDevice(int index)
        {
            OpenTabletDriver.Plugin.Log.Write("AudioToggle", "Toggle output Device" + index);
            if (index < 0)
            {
                string output = ExecuteCommand("amixer sget 'Master'");
                OpenTabletDriver.Plugin.Log.Write("Plugin", output);
                if (output.Contains("[on]"))
                {
                    ExecuteCommand("amixer sset 'Master' off");
                }
                else
                {
                    ExecuteCommand("amixer sset 'Master' on");
                }
            }
        }

        public void ToggleInputDevice(int index)
        {
            OpenTabletDriver.Plugin.Log.Write("Plugin", "Toggle input Device" + index);
            if (index < 0)
            {
                string output = ExecuteCommand("amixer sget 'Capture'");
                OpenTabletDriver.Plugin.Log.Write("Plugin", output);
                if (output.Contains("[on]"))
                {
                    ExecuteCommand("amixer sset 'Capture' off");
                }
                else
                {
                    ExecuteCommand("amixer sset 'Capture' on");
                }
            }
        }

        string ExecuteCommand(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"aplay {escapedArgs}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }
    }
}
