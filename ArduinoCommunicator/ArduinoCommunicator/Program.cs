using System;
using System.Collections.Generic;
using BackEndServices;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using BackEndServices.Database;
using BackEndServices.Room;

namespace ArduinoCommunicator
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             CommunicatorActions communicator = new CommunicatorActions(new MySQLDatabaseAccess("127.0.0.1", "WorldGoals", "test", "rSFC68k0QY"));

            ISimpleRoom[] rooms = communicator.GetRooms();
            for (int i = 0; i < rooms.Length; i++)
            {
                Console.WriteLine(rooms[i].GUID);
            }

            while (true)
            {
                

                GetData();

                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        async static void GetData()
        {
            HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:5000");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }
    }
}
