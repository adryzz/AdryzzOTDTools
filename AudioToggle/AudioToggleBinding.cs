using System;
using System.Runtime.InteropServices;
using System.Threading;
using AudioToggle.Platforms.Linux;
using AudioToggle.Platforms.Windows;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;

namespace AudioToggle
{
    [PluginName("Audio Toggle"), SupportedPlatform(PluginPlatform.Windows /*| PluginPlatform.Linux*/)]
    public class AudioToggleBinding : IBinding
    {
        public static string[] ValidProperties => new string[] { "Toggle output device 1", "PTT output device 1", "Toggle input device 1", "PTT input device 1", "Toggle output device 2", "PTT output device 2", "Toggle input device 2", "PTT input device 2", "List audio devices" };

        [Property("Action"), PropertyValidated(nameof(ValidProperties))]
        public string Property { set; get; }

        public static IAudioToggle Instance;

        public static int[] OutputDevices = new int[2] { -1, -1 };
        public static int[] InputDevices = new int[2] { -1, -1 };


        [Property("Output device 1 index"), DefaultPropertyValue(-1)]
        public int OutputDevice1 { get => OutputDevices[0]; set => OutputDevices[0] = value; }

        [Property("Input device 1 index"), DefaultPropertyValue(-1)]
        public int InputDevice1 { get => InputDevices[0]; set => InputDevices[0] = value; }

        [Property("Output device 2 index"), DefaultPropertyValue(-1)]
        public int OutputDevice2 { get => OutputDevices[1]; set => OutputDevices[1] = value; }

        [Property("Input device 1 index"), DefaultPropertyValue(-1)]
        public int InputDevice2 { get => InputDevices[1]; set => InputDevices[1] = value; }

        void IBinding.Press(IDeviceReport report)
        {
            if (Instance == null || Instance.Disposed)
            {
                Initialize();
            }

            switch (Property)
            {
                case "Toggle output device 1":
                    {
                        Instance.ToggleOutputDevice(OutputDevices[0]);
                        break;
                    }
                case "PTT output device 1":
                    {
                        Instance.ToggleOutputDevice(InputDevices[0]);
                        break;
                    }
                case "Toggle input device 1":
                    {
                        Instance.ToggleInputDevice(InputDevices[0]);
                        break;
                    }
                case "PTT input device 1":
                    {
                        Instance.ToggleInputDevice(InputDevices[0]);
                        break;
                    }
                case "Toggle output device 2":
                    {
                        Instance.ToggleOutputDevice(OutputDevices[1]);
                        break;
                    }
                case "PTT output device 2":
                    {
                        Instance.ToggleOutputDevice(InputDevices[1]);
                        break;
                    }
                case "Toggle input device 2":
                    {
                        Instance.ToggleInputDevice(InputDevices[1]);
                        break;
                    }
                case "PTT input device 2":
                    {
                        Instance.ToggleInputDevice(InputDevices[1]);
                        break;
                    }
                case "List audio devices":
                    {
                        Instance.ListDevices();
                        break;
                    }
            }
        }

        void IBinding.Release(IDeviceReport report)
        {
            if (Instance == null || Instance.Disposed)
            {
                Initialize();
            }

            switch (Property)
            {
                case "PTT output device 1":
                    {
                        Instance.ToggleOutputDevice(InputDevices[0]);
                        break;
                    }
                case "PTT input device 1":
                    {
                        Instance.ToggleInputDevice(InputDevices[0]);
                        break;
                    }
                case "PTT output device 2":
                    {
                        Instance.ToggleOutputDevice(InputDevices[1]);
                        break;
                    }
                case "PTT input device 2":
                    {
                        Instance.ToggleInputDevice(InputDevices[1]);
                        break;
                    }
            }
        }

        void Initialize()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Instance == null || Instance.Disposed)
                {
                    Instance = new WindowsAudioToggle();
                    Instance.Initialize();
                }
            }
            else
            {
                if (Instance == null || Instance.Disposed)
                {
                    Instance = new LinuxAudioToggle();
                    Instance.Initialize();
                }
            }
        }
    }
}
