using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi.CoreAudio;
using OpenTabletDriver.Plugin;

namespace AudioToggle
{
    class WindowsAudioToggle : IAudioToggle
    {
        public bool Initialized { get; set; }
        public bool Disposed { get; set; }

        CoreAudioController controller;

        public void Dispose()
        {
            Disposed = true;
            
        }

        public bool Initialize()
        {
            controller = new CoreAudioController();
            Initialized = true;
            return true;
        }

        public string ListDevices()
        {
            var playback = controller.GetPlaybackDevices().ToArray();
            var capture = controller.GetCaptureDevices().ToArray();
            string p = "Playback devices:\n";
            for(int i = 0; i < playback.Length; i++)
            {
                p += string.Format("Device {0}: {1}\n", i, playback[i].FullName);
            }

            string c = "Capture devices:\n";
            for (int i = 0; i < capture.Length; i++)
            {
                c += string.Format("Device {0}: {1}\n", i, capture[i].FullName);
            }
            return p + c;
        }

        public void ToggleOutputDevice(int index)
        {
            if (index < 0)
            {
                controller.DefaultPlaybackDevice.ToggleMute();
                return;
            }
            var dev = controller.GetPlaybackDevices().ToArray()[index];
            dev.ToggleMute();
            Log.Write("AudioToggle", "Toggle mute for " + dev.FullName);
        }

        public void ToggleInputDevice(int index)
        {
            if (index < 0)
            {
                controller.DefaultCaptureDevice.ToggleMute();
                return;
            }
            var dev = controller.GetCaptureDevices().ToArray()[index];
            dev.ToggleMute();
            Log.Write("AudioToggle", "Toggle mute for " + dev.FullName);
        }
    }
}
