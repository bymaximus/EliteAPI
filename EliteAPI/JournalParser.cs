using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;

namespace EliteAPI
{
    internal class JournalParser
    {
        internal JournalParser(EliteDangerousAPI EliteAPI)
        {

            this.EliteAPI = EliteAPI;
        }

        private EliteDangerousAPI EliteAPI;
        internal List<string> processedLogs = new List<string>();

        public void ProcessJournal(FileInfo logFile, bool doNotTrigger = true)
        {
			try
			{
				using (StreamReader reader = new StreamReader(new FileStream(logFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
				{
					long lastMaxOffset = reader.BaseStream.Length;
					string line = "";
					while (true &&
						this.isRunning
					)
					{
						Thread.Sleep(100);
						if (reader.BaseStream.Length == lastMaxOffset)
						{
							continue;
						}
						reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);
						line = "";
						while ((line = reader.ReadLine()) != null)
						{
							/*Console.WriteLine("LINE " + line);
							Console.WriteLine(" ");*/
							try
							{
								ProcessJson(line);
							}
							catch (Exception err)
							{
								Console.WriteLine(err.Message);
							}							
						}
						lastMaxOffset = reader.BaseStream.Position;
					}
				}
			}
			catch (Exception err)
			{

			}			
        }

        public void ProcessJson(string json)
        {
            dynamic obj = null;
            string eventName = "";

            try
            {
                //Turn the JSON into an object to find out which event it is.
                obj = JsonConvert.DeserializeObject<dynamic>(json);
                eventName = obj.@event;
                EliteAPI.Logger.LogDebug($"Processing event '{eventName}'.");
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Couldn't process JSON ({json}).", ex); }

            //Invoke the matching event.
            Type eventClass; MethodInfo eventMethod;

            try
            {
                eventClass = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == $"{eventName}Info").First();
                try
                {
                    eventMethod = eventClass.GetMethod("Process");
                    try { eventMethod.Invoke(null, new object[] { json, EliteAPI }); }
                    catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke event method '{eventName}Info.Process()'.", ex); }
                }
                catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event method '{eventName}Info.Process()'.", ex); }
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event class '{eventName}Info'.", ex); }

            //Invoke the AllEvent.
            try { EliteAPI.Events.InvokeAllEvent(obj); }
            catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke AllEvent for '{eventName}'.", ex); }
        }
    }
}
