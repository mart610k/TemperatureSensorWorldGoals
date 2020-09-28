using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndServices.Database;
using BackEndServices.Sensor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WordGoalsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        WebDataActions dataActions;

        public SensorController()
        {
            Dictionary<string, string> config = BackEndServices.ConfigReader.Config.ReadConfig(@"D:\Skole\H3\TemperatureSensorWorldGoals\mysqlConnectionConfig.cfg");

            dataActions = new WebDataActions(new MySQLDatabaseAccess(config["host"], config["databasename"], config["username"], config["password"]));
        }

        [HttpGet("Sensors")]
        public IEnumerable<ISensor> Get()
        {
            return dataActions.GetAllSensors();
        }

        [HttpGet("Sensor")]
        public ISensor GetSensorByName([FromQuery(Name = "Name")] string page)
        {
            return dataActions.GetSensorByName(page);
        }

        [HttpGet("Room")]
        public ISensor[] GetSensorsFromRoom([FromQuery(Name = "uuid")] string roomUUID)
        {
            return dataActions.GetSensorsForRoom(roomUUID);
        }

        
    }
}
