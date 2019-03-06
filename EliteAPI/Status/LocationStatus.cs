namespace EliteAPI.Status
{
    public class LocationStatus
    {
        internal LocationStatus(EliteDangerousAPI api)
        {
            api.Events.LocationEvent += (sender, e) => { 
				StarSystem = e.StarSystem; 
				Body = e.Body; 
				BodyType = e.BodyType; 
				
				lastSystem.Address = e.SystemAddress;
				lastSystem.Allegiance = e.SystemAllegiance;
				lastSystem.Economy = e.SystemEconomy;
				lastSystem.Economy_Localised = e.SystemEconomyLocalised;
				lastSystem.FactionState = "???";
				lastSystem.Government = e.SystemGovernment;
				lastSystem.Government_Localised = e.SystemGovernmentLocalised;
				lastSystem.Name = e.StarSystem;
				lastSystem.Population = (ulong)e.Population;
				lastSystem.Position = e.StarPos;
				lastSystem.SecondEconomy = e.SystemSecondEconomy;
				lastSystem.SecondEconomy_Localised = e.SystemSecondEconomyLocalised;
				lastSystem.Security = e.SystemSecurity;
				lastSystem.Security_Localised = e.SystemSecurityLocalised;
				lastSystem.SystemFaction = e.SystemFaction.Name;

				lastStation.System = lastSystem;

				lastBody.Name = e.Body;
				lastBody.Type = e.BodyType;
				lastBody.ID = (int)e.BodyId;				
			};
            api.Events.ApproachBodyEvent += (sender, e) => { 
				StarSystem = e.StarSystem; 
				Body = e.Body; 
				BodyType = "Planet"; 
								
				lastBody.Name = e.Body;
				lastBody.ID = (int)e.BodyId;
				lastBody.Type = "Planet";				
				
				if (e.StarSystem != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.StarSystem;
					StarSystem = e.StarSystem;
				}				
			};
            api.Events.LeaveBodyEvent += (sender, e) => { 
				StarSystem = e.StarSystem; 
				Body = e.Body; 
				BodyType = "Planet"; 
				
				lastBody.Name = e.Body;
				lastBody.ID = (int)e.BodyId;
				lastBody.Type = "Planet";				
				
				if (e.StarSystem != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.StarSystem;
					StarSystem = e.StarSystem;
				}								
			};
            api.Events.DockedEvent += (sender, e) => { 
				Station = e.StationName; 
				
				lastSystem.Name = e.StarSystem;
				lastSystem.Address = e.SystemAddress;

				lastStation.Allegiance = e.StationAllegiance;
				lastStation.DistFromStarLS = e.DistFromStarLs;
				lastStation.Economies = e.StationEconomies;
				lastStation.Economy = e.StationEconomy;
				lastStation.Economy_Localised = e.StationEconomyLocalised;
				lastStation.Faction = e.StationFaction.Name;
				lastStation.FactionState = "??";
				lastStation.Government = e.StationGovernment;
				lastStation.Government_Localised = e.StationGovernmentLocalised;
				lastStation.MarketID = e.MarketId;
				lastStation.Name = e.StationName;
				lastStation.Services = e.StationServices;
				lastStation.System = lastSystem;
				lastStation.Type = e.StationType;				
			};
            api.Events.DockingRequestedEvent += (sender, e) => { 
				Station = e.StationName; 
				
				lastStation.Name = e.StationName;
				lastStation.Type = e.StationType;
				lastStation.MarketID = e.MarketId;				
			};
            api.Events.FSDJumpEvent += (sender, e) => { 
				lastSystem.Address = e.SystemAddress;
				lastSystem.Allegiance = e.SystemAllegiance;
				lastSystem.Economy = e.SystemEconomy;
				lastSystem.Economy_Localised = e.SystemEconomyLocalised;
				lastSystem.Government = e.SystemGovernment;
				lastSystem.Government_Localised = e.SystemGovernmentLocalised;				
				lastSystem.Population = (ulong)e.Population;
				lastSystem.Position = e.StarPos;
				lastSystem.SecondEconomy = e.SystemSecondEconomy;
				lastSystem.SecondEconomy_Localised = e.SystemSecondEconomyLocalised;
				lastSystem.Security = e.SystemSecurity;
				lastSystem.Security_Localised = e.SystemSecurityLocalised;
				StarSystem = e.StarSystem;
			};
			
			api.Events.ScreenshotEvent += (sender, e) => { 
				if (e.System != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.System;
					StarSystem = e.System;
				}				
			};
			api.Events.StartJumpEvent += (sender, e) => { 
				if (e.StarSystem != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.StarSystem;
					StarSystem = e.StarSystem;
				}			
			};			
			api.Events.FSSAllBodiesFoundEvent += (sender, e) => { 
				if (e.SystemName != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.SystemName;
					StarSystem = e.SystemName;
				}		
			};				
			api.Events.MarketEvent += (sender, e) => { 
				if (e.StarSystem != "" &&
					(lastSystem.Name == "" ||
					lastSystem.Name == null)
				)
				{
					lastSystem.Name = e.StarSystem;
					StarSystem = e.StarSystem;
				}						
			};							
			api.Events.SupercruiseEntryEvent += (sender, e) => { 
				lastSystem.Address = e.SystemAddress;
				lastSystem.Name = e.StarSystem;
				StarSystem = e.StarSystem;
			};				
			api.Events.SupercruiseExitEvent += (sender, e) => { 
				Body = e.Body;
				BodyType = e.BodyType;
				lastBody.Name = e.Body;
				lastBody.ID = (int)e.BodyId;
				lastBody.Type = e.BodyType;

				StarSystem = e.StarSystem;
				lastSystem.Name = e.StarSystem;
				lastSystem.Address = e.SystemAddress;
			};							
        }

        public string StarSystem { get; private set; }
        public string Body { get; private set; }
        public string BodyType { get; private set; }
        public string Station { get; private set; }
		
        /// <summary>
        /// Contains information on the most recent body visited.
        /// </summary>
        public Body lastBody = new Body();

        /// <summary>
        /// Contains information on the most recent system visited.
        /// </summary>
        public SystemClass lastSystem = new SystemClass();

        /// <summary>
        /// Contains information on the most recent station visited.
        /// </summary>
        public Station lastStation = new Station();		
    }
}