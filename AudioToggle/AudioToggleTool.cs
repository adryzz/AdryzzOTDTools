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
        public static int[] InputDevices = new int[2] { -1, -1 };
        public static int[] ChangeInputDevices = new int[2] { -1, -1 };
        public static int[] ChangeOutputDevices = new int[2] { -1, -1 };

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

        [Property("Change output device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeOutputDevice1 { get => ChangeOutputDevices[0]; set => ChangeOutputDevices[0] = value; }

        [Property("Change output device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeOutputDevice2 { get => ChangeOutputDevices[1]; set => ChangeOutputDevices[1] = value; }

        [Property("Input device 1 index"), DefaultPropertyValue(-1)]
        public int InputDevice1 { get => InputDevices[0]; set => InputDevices[0] = value; }

        [Property("Input device 2 index"), DefaultPropertyValue(-1)]
        public int InputDevice2 { get => InputDevices[1]; set => InputDevices[1] = value; }

        [Property("Change input device 1 index"), DefaultPropertyValue(-1)]
        public int ChangeInputDevice1 { get => ChangeInputDevices[0]; set => ChangeInputDevices[0] = value; }

        [Property("Change input device 2 index"), DefaultPropertyValue(-1)]
        public int ChangeInputDevice2 { get => ChangeInputDevices[1]; set => ChangeInputDevices[1] = value; }
    }
}
