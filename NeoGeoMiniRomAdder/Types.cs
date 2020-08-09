using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGeoMiniRomAdder {
    public enum EmulatorType { fba, fc, sfc, md, gbc, gba, ng, ra, pce};//wtf is ra? it's only used for mvc2...
    public class RomInfo {
        public string ID { get; set; }
        public EmulatorType EMU { get; set; }
        public string EmuString { get {
                switch (EMU) {
                    case EmulatorType.fc: return "nes";
                    case EmulatorType.sfc: return "snes";
                    case EmulatorType.md: return "genesis";
                    case EmulatorType.gbc: return "gb"; //contains gb and gbc.
                    default: return EMU.ToString();
                }
            } }
        public string ASPString { get {
                switch (EMU) {
                    case EmulatorType.sfc: return "SNES";
                    case EmulatorType.md: return "SEGA";
                    default: return EMU.ToString();
                }
            } }
        public string PATH { get; set; }
    }
    public class ExtendedRomInfo {
        public int ID { get; set; }
        public int Type { get; set; } = 5;
        public string Name { get; set; }
        public string Dir { get; set; }
        public string LCDImage { get; set; }
        public bool NewImage { get; set; }
        public string TVImage { get; set; }
        public string CoverImage { get; set; }
        public string FlyerImage { get; set; }
        public string GameINI { get; set; }
        public bool IsNew { get; set; } = false;
    }
    public class Emu {
        public EmulatorType Type { get; set; }
    }
}
