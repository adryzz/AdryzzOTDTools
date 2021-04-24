using OpenTabletDriver.Plugin.Tablet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OTDTestFilter
{
    class EraserSwitcherReport : IEraserReport, ITabletReport
    {
        public bool Eraser { get; set; }
        public uint ReportID { get; set; }
        public Vector2 Position { get; set; }
        public uint Pressure { get; set; }
        public bool[] PenButtons { get; set; }
        public byte[] Raw { get; set; }

        public EraserSwitcherReport(ITabletReport report, bool eraser)
        {
            Raw = report.Raw;
            ReportID = report.ReportID;
            Position = report.Position;
            Pressure = report.Pressure;
            PenButtons = report.PenButtons;
            Eraser = eraser;
        }
    }
}
