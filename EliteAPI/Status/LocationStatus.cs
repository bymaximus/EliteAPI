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
				lastSystem.Economy_Localised = e.SystemEconomy_Localised;
				lastSystem.FactionState = e.FactionState;
				lastSystem.Government = e.SystemGovernment;
				lastSystem.Government_Localised = e.SystemGovernment_Localised;
				lastSystem.Name = e.StarSystem;
				lastSystem.Population = e.Population;
				lastSystem.Position = e.StarPos;
				lastSystem.SecondEconomy = e.SystemSecondEconomy;
				lastSystem.SecondEconomy_Localised = e.SystemSecondEconomy_Localised;
				lastSystem.Security = e.SystemSecurity;
				lastSystem.Security_Localised = e.SystemSecurity_Localised;
				lastSystem.SystemFaction = e.SystemFaction;

				lastStation.Name = e.StationName;
				lastStation.Type = e.StationType;
				lastStation.System = lastSystem;

				lastBody.Name = e.Body;
				lastBody.Type = e.BodyType;
				lastBody.ID = e.BodyID;				
			};
            api.Events.ApproachBodyEvent += (sender, e) => { 
				StarSystem = e.StarSystem; 
				Body = e.Body; 
				BodyType = "Planet"; 
								
				lastBody.Name = e.Body;
				lastBody.ID = e.BodyID;
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
				lastBody.ID = e.BodyID;
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
				lastStation.DistFromStarLS = e.DistFromStarLS;
				lastStation.Economies = e.StationEconomies;
				lastStation.Economy = e.StationEconomy;
				lastStation.Economy_Localised = e.StationEconomy_Localised;
				lastStation.Faction = e.StationFaction;
				lastStation.FactionState = e.FactionState;
				lastStation.Government = e.StationGovernment;
				lastStation.Government_Localised = e.StationGovernment_Localised;
				lastStation.MarketID = e.MarketID;
				lastStation.Name = e.StationName;
				lastStation.Services = e.StationServices;
				lastStation.System = lastSystem;
				lastStation.Type = e.StationType;				
			};
            api.Events.DockingRequestedEvent += (sender, e) => { 
				Station = e.StationName; 
				
				lastStation.Name = e.StationName;
				lastStation.Type = e.StationType;
				lastStation.MarketID = e.MarketID;				
			};
            api.Events.FSDJumpEvent += (sender, e) => { 
				lastSystem.Address = e.SystemAddress;
				lastSystem.Allegiance = e.SystemAllegiance;
				lastSystem.Economy = e.SystemEconomy;
				lastSystem.Economy_Localised = e.SystemEconomy_Localised;
				lastSystem.Government = e.SystemGovernment;
				lastSystem.Government_Localised = e.SystemGovernment_Localised;				
				lastSystem.Population = e.Population;
				lastSystem.Position = e.StarPos;
				lastSystem.SecondEconomy = e.SystemSecondEconomy;
				lastSystem.SecondEconomy_Localised = e.SystemSecondEconomy_Localised;
				lastSystem.Security = e.SystemSecurity;
				lastSystem.Security_Localised = e.SystemSecurity_Localised;
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
				lastBody.ID = e.BodyID;
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