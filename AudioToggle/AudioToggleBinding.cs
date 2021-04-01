using System;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;

namespace AudioToggle
{
    [PluginName("Audio Toggle"), SupportedPlatform(PluginPlatform.Windows | PluginPlatform.Linux)]
    public class AudioToggleBinding : IValidateBinding, IBinding
    {

        [Property("Property")]
        public string Property { get; set; }

        public Action Press => (Action)RunAction;

        public Action Release => (Action)(() => { });

        public string[] ValidProperties => new string[] { "Toggle output device 1", "Toggle input device 1", "Toggle output device 2", "Toggle input device 2", "List audio devices" };

        void RunAction()
        {
            if (AudioToggleTool.Instance == null || AudioToggleTool.Instance.Disposed)
            {
                Log.Write("AudioToggle", "Tool instance not initialized", LogLevel.Error);
                return;
            }

            switch (Property)
            {
                case "Toggle output device 1":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.OutputDevices[0]);
                        break;
                    }
                case "Toggle input device 1":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "Toggle output device 2":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.OutputDevices[1]);
                        break;
                    }
                case "Toggle input device 2":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
                case "List audio devices":
                    {
                        AudioToggleTool.Instance.ListDevices();
                        break;
                    }
            }
        }
    }
}
