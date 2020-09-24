using System;
using System.Collections.Generic;
using BackEndServices;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using BackEndServices.Database;
using BackEndServices.Room;
using BackEndServices.Sensor;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

namespace ArduinoCommunicator
{
    class Program
    {


        public static CommunicatorActions communicator; 

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            SensorUpdater sensorUpdater = SensorUpdater.GetInstance();
            sensorUpdater.StopAndJoinThreads();
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static Dictionary<string, string> ReadConfigFile()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();

            using (StreamReader str = new StreamReader(@"D:\Skole\H3\TemperatureSensorWorldGoalsOld\mysqlConnectionConfig.cfg"))
            {
                string configFile = str.ReadToEnd();
                string[] tmp = configFile.Split(Environment.NewLine);

                for (int i = 0; i < tmp.Length; i++)
                {
                    Console.WriteLine(tmp[i]);
                    string[] values = tmp[i].Split("=");
                    config.Add(values[0], values[1]);
                }
            }
            return config;
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Dictionary<string, string> config = ReadConfigFile();

            communicator = new CommunicatorActions(new MySQLDatabaseAccess(config["host"], config["databasename"], config["username"], config["password"]));

            List<IRoom> rooms = GetRooms(communicator, communicator.GetRooms());
            
            SensorUpdater updater = SensorUpdater.GetInstance();

            for (int i = 0; i < rooms.Count; i++)
            {
                updater.RegisterThread(rooms[i].GUID.ToString(),rooms[i].IPaddress, 5);
            }
            Console.ReadKey();

            updater.StopAndJoinThreads();

            Console.ReadKey();
        }

        public static List<IRoom> GetRooms(ICommonDataMethods commonDataMethods, ISimpleRoom[] uuid)
        {
            List<IRoom> rooms = new List<IRoom>();

            for (int i = 0; i < uuid.Length; i++)
            {
                rooms.Add(commonDataMethods.GetRoomDetailed(uuid[i].GUID.ToString()));
            }
            return rooms;
        }
    }
}
