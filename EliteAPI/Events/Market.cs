namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
	using Newtonsoft.Json.Linq;

    public partial class MarketInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
		
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

    public partial class MarketInfo
    {
        public static MarketInfo Process(string json, EliteDangerousAPI api) => {
			MarketInfo market = JsonConvert.DeserializeObject<MarketInfo>(json, EliteAPI.Events.MarketConverter.Settings);
			market.ScanCommodities(api.MarketData);
			api.Events.InvokeMarketEvent(market);
		};
    }

    public static class MarketSerializer
    {
        public static string ToJson(this MarketInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MarketConverter.Settings);
    }

    internal static class MarketConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
