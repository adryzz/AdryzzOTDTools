using System;
using System.Runtime.InteropServices;
using System.Threading;
using AudioToggle.Platforms.Linux;
using AudioToggle.Platforms.Windows;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;

namespace AudioToggle
{
    [PluginName("Audio Toggle Configuration"), SupportedPlatform(PluginPlatform.Windows /*| PluginPlatform.Linux*/)]
    public class AudioToggleTool : ITool
    {
        public static IAudioToggle Instance;

        public static int[] OutputDevices = new int[2] { -1, -1 };
        public static int[] ChangeStandardOutputDevices = new int[2] { -1, -1 };
        public static int[] ChangeCommsOutputDevices = new int[2] { -1, -1 };
        public static int[] InputDevices = new int[2] { -1, -1 };
        public static int[] ChangeStandardInputDevices = new int[2] { -1, -1 };
        public static int[] ChangeCommsInputDevices = new int[2] { -1, -1 };

        public AudioToggleTool()
        {

        }

        public bool Initialize()
        {
            new Thread(new ThreadStart(InitializeAsync)).Start();
            return true;
        }

        void InitializeAsync()
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

        public void Dispose()
        {
            Instance.Dispose();
        }

        [Property("Output device 1 index"), DefaultPropertyValue(-1)]
        public int OutputDevice1 { get => OutputDevices[0]; set => OutputDevices[0] = value; }

        [Property("Output device 2 index"), DefaultPropertyValue(-1)]
        public int OutputDevice2 { get => OutputDevices[1]; set => OutputDevices[1] = value; }

        [Property("Change standard output device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeStandardOutputDevice1 { get => ChangeStandardOutputDevices[0]; set => ChangeStandardOutputDevices[0] = value; }

        [Property("Change standard output device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeStandardOutputDevice2 { get => ChangeStandardOutputDevices[1]; set => ChangeStandardOutputDevices[1] = value; }

        [Property("Change comms output device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeCommsOutputDevice1 { get => ChangeCommsOutputDevices[0]; set => ChangeCommsOutputDevices[0] = value; }

        [Property("Change comms output device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeCommsOutputDevice2 { get => ChangeCommsOutputDevices[1]; set => ChangeCommsOutputDevices[1] = value; }

        [Property("Input device 1 index"), DefaultPropertyValue(-1)]
        public int InputDevice1 { get => InputDevices[0]; set => InputDevices[0] = value; }

        [Property("Input device 2 index"), DefaultPropertyValue(-1)]
        public int InputDevice2 { get => InputDevices[1]; set => InputDevices[1] = value; }

        [Property("Change standard input device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeInputDevice1 { get => ChangeStandardInputDevices[0]; set => ChangeStandardInputDevices[0] = value; }

        [Property("Change standard input device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeInputDevice2 { get => ChangeStandardInputDevices[1]; set => ChangeStandardInputDevices[1] = value; }

        [Property("Change comms input device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeCommsInputDevice1 { get => ChangeCommsInputDevices[0]; set => ChangeCommsInputDevices[0] = value; }

        [Property("Change comms input device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeCommsInputDevice2 { get => ChangeCommsInputDevices[1]; set => ChangeCommsInputDevices[1] = value; }
    }
}
