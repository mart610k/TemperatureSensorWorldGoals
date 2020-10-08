using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public class WebDataActions : CommonDataMethods, IWebDataActions
    {
        public WebDataActions(IDatabaseAccess databaseAccess) : base(databaseAccess)
        {
        }

        public ISensorLimit GetSensorLimit(int sensorID)
        {
            return DatabaseAccess.GetSensorLimit(sensorID);
        }

        public ISensorLimit GetSensorLimitForRoom(string roomUUID, int sensorID)
        {
            return DatabaseAccess.GetSensorForLimitForRoom(roomUUID, sensorID);   
        }

        public ISensorReading[] GetSensorReadings(string roomUUID, int sensorID, int count)
        {
            return DatabaseAccess.GetSensorReadings(roomUUID, sensorID, count);
        }

        public bool SetSensorLimitForRoom(string roomUUID, ISensorLimit sensorLimit)
        {
            return DatabaseAccess.SetSensorLimitForRoom(roomUUID, sensorLimit);
        }
    }
}
