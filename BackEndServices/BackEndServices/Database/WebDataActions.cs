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

        public ISensorLimit GetSensorLimitForRoom(string roomUUID, int sensorID)
        {
            return DatabaseAccess.LoadData<ISensorLimit>(string.Format("Select SensorTypeID,hex(SensorID),UpperLimit,LowerLimit from CustomSensorLimit where SensorID = unhex(\"{0}\") and SensorTypeID = {1};", roomUUID, sensorID))[0];
        }

        public ISensorReading[] GetSensorReadings(string roomUUID, int sensorID, int count)
        {
            return DatabaseAccess.LoadData<ISensorReading>(string.Format("Select hex(SensorID),SensorTypeID,TimeRead,ValueRead from SensorReading where SensorID = unhex(\"{0}\") and SensorTypeID = {1} Limit {2}", roomUUID, sensorID, count)).ToArray();


        }

        public bool SetSensorLimitForRoom(string roomUUID, ISensorLimit sensorLimit)
        {
            throw new NotImplementedException();
        }
    }
}
