using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public interface IWebDataActions
    {
        ISensorReading[] GetSenssorReadings(string roomUUID, int sensorID, int count);

        ISensorLimit GetSensorLimitForRoom(string roomUUID, int sensorID);

        bool SetSensorLimitForRoom(string roomUUID, ISensorLimit sensorLimit);
    }
}
