using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class LocationInfo
    {
        public class RecoveringStateInfo
        {
            public string State { get; }
            public int Trend { get; }
        }

        public class FactionInfo
        {
            public string Name { get; }
            public string FactionState { get; }
            public string Government { get; }
            public double Influence { get; }
            public string Allegiance { get; }
            public List<RecoveringStateInfo> RecoveringStates { get; }
        }

        public DateTime timestamp { get; set; }
        public bool Docked { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public ulong Population { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
        public List<FactionInfo> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }
    }
}
