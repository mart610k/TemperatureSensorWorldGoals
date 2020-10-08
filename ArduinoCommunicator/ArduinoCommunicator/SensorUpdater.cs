using BackEndServices.Sensor;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using BackEndServices.Database;

namespace ArduinoCommunicator
{
    class SensorUpdater
    {
        private List<Thread> threads;

        static bool threadsShouldRun = true;

        static object threadShouldRunLock = new object();

        static SensorUpdater SensorUpdaterSingleton;

        static object SensorUpdaterSingletonLock = new object();

        public static SensorUpdater GetInstance()
        {
            lock (SensorUpdaterSingletonLock)
            {
                if (SensorUpdaterSingleton == null)
                {
                    SensorUpdaterSingleton = new SensorUpdater();
                }
                return SensorUpdaterSingleton;
            }
        }
        private SensorUpdater()
        {
            threads = new List<Thread>();
        }

        public bool StopAndJoinThreads()
        {
            lock (threadShouldRunLock)
            {
                threadsShouldRun = false;
            }

            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }

            threads = new List<Thread>();


            return true;
        }


        public bool RegisterThread(CommunicatorActions commonDataMethods, string roomUUID, string host, int waitingTimeInSeconds)
        {
            Thread thread = new Thread(() => SensorGetter(commonDataMethods, roomUUID, host, waitingTimeInSeconds));
            thread.Start();
            threads.Add(thread);
            return true;
        }

        private void SensorGetter(CommunicatorActions commonDataMethods, string roomUUID,string host, int waitingTimeInSeconds)
        {
            HttpClient client = new HttpClient();

            client.Timeout = TimeSpan.FromSeconds(5);

            while (threadsShouldRun)
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("http://" + host).GetAwaiter().GetResult();

                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            JObject jObject = JObject.Parse(responseBody);

                            List<string> keys = jObject.Properties().Select(p => p.Name).ToList();
                            for (int i = 0; i < keys.Count; i++)
                            {
                                JToken jToken = jObject.GetValue(keys[i]);

                                if(jToken.Type == JTokenType.Float || jToken.Type == JTokenType.Integer)
                                {
                                    float valueRead = (float)jToken;
                                    ISensor sensor = commonDataMethods.GetSensorByName(keys[i]);
                                    ISensorReading sensorReading = new SensorReading(sensor.SensorID, sensor.SensorName, DateTime.UtcNow, valueRead);

                                    commonDataMethods.CreateSensorReading(roomUUID, sensorReading);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    
                }
                Thread.Sleep(waitingTimeInSeconds * 1000);
            }
        
            client.Dispose();

            Program.PrintMessage("Awaiting to be joined");
        }

}
}
