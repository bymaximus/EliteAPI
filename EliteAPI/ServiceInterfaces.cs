using System.Diagnostics;
using System.IO;

using EliteAPI.Bindings;
//using EliteAPI.Discord;

namespace EliteAPI
{
	public interface IEliteDangerousAPI
    {
        //Version info.
        string Version { get; }

        //Public fields.
        bool IsRunning { get; }
        DirectoryInfo JournalDirectory { get; }
        bool SkipCatchUp { get; }
        Events.EventHandler Events { get; }
        Logging.Logger Logger { get; }
		EliteAPI.Status.ShipStatus Status { get; }
		EliteAPI.Status.ShipCargo Cargo { get; }
		EliteAPI.Status.ShipModules Modules { get; }
        UserBindings Bindings { get; }
		EliteAPI.Status.CommanderStatus Commander { get; }
		EliteAPI.Status.LocationStatus Location { get; }

        //Services.
        //RichPresenceClient DiscordRichPresence { get; }

        //Methods.
        void Reset();
        void Start();
        void Stop();
    }
}