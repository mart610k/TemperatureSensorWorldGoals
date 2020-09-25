using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndServices.Database;
using BackEndServices.Room;
using BackEndServices.Sensor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WordGoalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        WebDataActions dataActions;

        public RoomController()
        {
            Dictionary<string, string> config = BackEndServices.ConfigReader.Config.ReadConfig(@"D:\Skole\H3\TemperatureSensorWorldGoals\mysqlConnectionConfig.cfg");


            dataActions = new WebDataActions(new MySQLDatabaseAccess(config["host"], config["databasename"], config["username"], config["password"]));
        }


        [HttpGet("Rooms")]
        public ISimpleRoom[] GetRooms()
        {
            return dataActions.GetRooms();
        }

        [HttpGet("Detailed")]
        public IRoom GetRoomDetailed([FromQuery(Name = "uuid")] string roomUUID)
        {
            return dataActions.GetRoomDetailed(roomUUID);
        }

        [HttpGet("Readings")]
        public ISensorReading[] GetReadings([FromQuery(Name = "Room")] string room,[FromQuery(Name = "SensorID")] int sensorID, [FromQuery(Name = "Count")] int count)
        {
            return dataActions.GetSensorReadings(room, sensorID, count);
        }

    }
}
