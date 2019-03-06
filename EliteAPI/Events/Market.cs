using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EliteAPI
{
    public class MarketInfo
    {
        public DateTime timestamp { get; set; }
		
		public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
		public List<Classes.Commodity> Commodities { get; set; }

		public void ScanCommodities(JObject evt)
		{
			Commodities = new List<Classes.Commodity>();
			if (evt != null &&
				evt.ContainsKey("timestamp") &&
				evt.ContainsKey("Items")
			)
			{
				JArray jcommodities = (JArray) evt["Items"];
				if (jcommodities != null)
				{
					foreach (JObject commodity in jcommodities)
					{
						Classes.Commodity com = new Classes.Commodity(commodity, true);
						Commodities.Add(com);
					}
					Commodities.Sort((l, r) => l.locName.CompareTo(r.locName));
				}
			}
		}
	}
}
