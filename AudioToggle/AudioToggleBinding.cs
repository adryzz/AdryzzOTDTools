using System;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;

namespace AudioToggle
{
    [PluginName("Audio Toggle"), SupportedPlatform(PluginPlatform.Windows /*| PluginPlatform.Linux*/)]
    public class AudioToggleBinding : IStateBinding, IBinding
    {

        [Property("Property"), PropertyValidated(nameof(ValidProperties))]
        public string Property { get; set; }

        public void Press(TabletReference tablet, IDeviceReport report)
        {
            RunAction();
            return;
        }

        public void Release(TabletReference tablet, IDeviceReport report)
        {
            StopAction();
            return;
        }
        

        public static string[] ValidProperties { get; } = new string[] { "Toggle output device 1", "Toggle output device 2", "PTT output device 1", "PTT output device 2", "Change output device 1", "Change output device 2", "Toggle input device 1", "Toggle input device 2", "PTT input device 1", "PTT input device 2", "Change input device 1", "Change input device 2", "List audio devices" };

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
                case "Toggle output device 2":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.OutputDevices[1]);
                        break;
                    }
                case "PTT output device 1":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "PTT output device 2":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
                case "Change output device 1":
                    {
                        AudioToggleTool.Instance.ChangeOutputDevice(AudioToggleTool.ChangeOutputDevices[0]);
                        break;
                    }
                case "Change output device 2":
                    {
                        AudioToggleTool.Instance.ChangeOutputDevice(AudioToggleTool.ChangeOutputDevices[1]);
                        break;
                    }
                case "Toggle input device 1":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "Toggle input device 2":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
                case "PTT input device 1":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "PTT input device 2":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
                case "Change input device 1":
                    {
                        AudioToggleTool.Instance.ChangeInputDevice(AudioToggleTool.ChangeOutputDevices[0]);
                        break;
                    }
                case "Change input device 2":
                    {
                        AudioToggleTool.Instance.ChangeInputDevice(AudioToggleTool.ChangeOutputDevices[1]);
                        break;
                    }
                case "List audio devices":
                    {
                        AudioToggleTool.Instance.ListDevices();
                        break;
                    }
            }
        }
        void StopAction()
        {
            if (AudioToggleTool.Instance == null || AudioToggleTool.Instance.Disposed)
            {
                Log.Write("AudioToggle", "Tool instance not initialized", LogLevel.Error);
                return;
            }

            switch (Property)
            {
                case "PTT output device 1":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "PTT output device 2":
                    {
                        AudioToggleTool.Instance.ToggleOutputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
                case "PTT input device 1":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[0]);
                        break;
                    }
                case "PTT input device 2":
                    {
                        AudioToggleTool.Instance.ToggleInputDevice(AudioToggleTool.InputDevices[1]);
                        break;
                    }
            }
        }
    }
}
