using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundPlayer
{
    [PluginName("Sound Player Configuration")]
    public class SoundPlayerTool : ITool
    {
        public static string[] Paths = new string[10];
        public static int OutDevice = -1;
        public static bool StopSoundOnRelease = false;

        public SoundPlayerTool()
        {

        }

        public bool Initialize()
        {
            return true;
        }

        public void Dispose()
        {

        }

        [Property("Output device index"), DefaultPropertyValue(-1)]
        public int OutputDevice1 { get => OutDevice; set => OutDevice = value; }

        [Property("Stop sound on release")]
        public bool StopSoundOnButtonRelease { get => StopSoundOnRelease; set => StopSoundOnRelease = value; }

        #region Audio Files

        [Property("Audio file 1")]
        public string AudioFile1 { get => Paths[0]; set => Paths[0] = value; }

        [Property("Audio file 2")]
        public string AudioFile2 { get => Paths[1]; set => Paths[1] = value; }

        [Property("Audio file 3")]
        public string AudioFile3 { get => Paths[2]; set => Paths[2] = value; }

        [Property("Audio file 4")]
        public string AudioFile4 { get => Paths[3]; set => Paths[3] = value; }

        [Property("Audio file 5")]
        public string AudioFile5 { get => Paths[4]; set => Paths[4] = value; }

        [Property("Audio file 6")]
        public string AudioFile6 { get => Paths[5]; set => Paths[5] = value; }

        [Property("Audio file 7")]
        public string AudioFile7 { get => Paths[6]; set => Paths[6] = value; }

        [Property("Audio file 8")]
        public string AudioFile8 { get => Paths[7]; set => Paths[7] = value; }

        [Property("Audio file 9")]
        public string AudioFile9 { get => Paths[8]; set => Paths[8] = value; }

        [Property("Audio file 10")]
        public string AudioFile10 { get => Paths[9]; set => Paths[9] = value; }

        #endregion
    }
}
