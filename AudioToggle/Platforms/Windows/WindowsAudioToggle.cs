using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi.CoreAudio;
using OpenTabletDriver.Plugin;

namespace AudioToggle.Platforms.Windows
{
    class WindowsAudioToggle : IAudioToggle
    {
        public bool Initialized { get; set; }
        public bool Disposed { get; set; }

        CoreAudioController controller;

        public void Dispose()
        {
            controller.Dispose();
            Disposed = true;
        }

        public bool Initialize()
        {
            controller = new CoreAudioController();
            Initialized = true;
            return true;
        }

        public void ListDevices()
        {
            try
            {
                if (controller == null)
                {
                    Initialize();
                }
                var playback = controller.GetPlaybackDevices().ToArray();
                var capture = controller.GetCaptureDevices().ToArray();
                string p = "Playback devices:\n";
                for (int i = 0; i < playback.Length; i++)
                {
                    p += string.Format("Device {0}: {1}\n", i, playback[i].FullName);
                }

                string c = "Capture devices:\n";
                for (int i = 0; i < capture.Length; i++)
                {
                    c += string.Format("Device {0}: {1}\n", i, capture[i].FullName);
                }
                Log.Write("AudioToggle", p + c);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        public void ToggleOutputDevice(int index)
        {
            try
            {
                if (controller == null)
                {
                    Initialize();
                }
                CoreAudioDevice dev;
                if (index < 0)
                {
                    dev = controller.DefaultPlaybackDevice;
                }
                else
                {
                    dev = controller.GetPlaybackDevices().ToArray()[index];
                }
                dev.ToggleMute();
                Log.Write("AudioToggle", "Toggle mute for " + dev.FullName, LogLevel.Debug);
            }
            catch(Exception ex)
            {
                Log.Exception(ex);
            }
        }

        public void ToggleInputDevice(int index)
        {
            try
            {
                if (controller == null)
                {
                    Initialize();
                }
                CoreAudioDevice dev;
                if (index < 0)
                {
                    dev = controller.DefaultCaptureDevice;
                }
                else
                {
                    dev = controller.GetCaptureDevices().ToArray()[index];
                }
                dev.ToggleMute();
                Log.Write("AudioToggle", "Toggle mute for " + dev.FullName, LogLevel.Debug);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        public void ChangeOutputDevice(int Standard, int Comms)
        {
            try
            {
                if (controller == null)
                {
                    Initialize();
                }
                CoreAudioDevice devStandard;
                CoreAudioDevice devComms;
                if (Standard < 0)
                {
                    devStandard = controller.DefaultPlaybackDevice;
                }
                else
                {
                    devStandard = controller.GetPlaybackDevices().ToArray()[Standard];
                }
                if (Comms < 0)
                {
                    devComms = controller.DefaultPlaybackDevice;
                }
                else
                {
                    devComms = controller.GetPlaybackDevices().ToArray()[Comms];
                }
                devStandard.SetAsDefault();
                devComms.SetAsDefaultCommunications();
                Log.Write("AudioToggle", "Set standard output device to " + devStandard.FullName, LogLevel.Debug);
                Log.Write("AudioToggle", "Set comms output device to " + devComms.FullName, LogLevel.Debug);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
        public void ChangeInputDevice(int Standard, int Comms)
        {
            try
            {
                if (controller == null)
                {
                    Initialize();
                }
                CoreAudioDevice devStandard;
                CoreAudioDevice devComms;
                if (Standard < 0)
                {
                    devStandard = controller.DefaultCaptureDevice;
                }
                else
                {
                    devStandard = controller.GetCaptureDevices().ToArray()[Standard];
                }
                if (Comms < 0)
                {
                    devComms = controller.DefaultCaptureDevice;
                }
                else
                {
                    devComms = controller.GetCaptureDevices().ToArray()[Comms];
                }
                devStandard.SetAsDefault();
                devComms.SetAsDefaultCommunications();
                Log.Write("AudioToggle", "Set standard input device to " + devStandard.FullName, LogLevel.Debug);
                Log.Write("AudioToggle", "Set comms input device to " + devComms.FullName, LogLevel.Debug);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
    }
}
