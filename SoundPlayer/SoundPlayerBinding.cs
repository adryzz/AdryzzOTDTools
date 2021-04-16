using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using System;
using NAudio;

namespace SoundPlayer
{

    [PluginName("Sound Player")]
    public class SoundPlayerBinding : IValidateBinding, IBinding
    {
        [Property("Property")]
        public string Property { get; set; }

        public Action Press => ButtonPress;

        public Action Release => ButtonRelease;

        public string[] ValidProperties => new string[] { "Play file 1", "Play file 2", "Play file 3", "Play file 4", "Play file 5", "Play file 6", "Play file 7", "Play file 8", "Play file 9", "Play file 10" };

        //wave out device
        WaveOut waveOut = new WaveOut();

        private void ButtonPress()
        {
            int index = int.Parse(Property.Remove(0, 10));
            string path = SoundPlayerTool.Paths[index];
        }

        private void ButtonRelease()
        {
            if (SoundPlayerTool.StopSoundOnRelease)
            {
                int index = int.Parse(Property.Remove(0, 10));
            }
        }
    }
}
