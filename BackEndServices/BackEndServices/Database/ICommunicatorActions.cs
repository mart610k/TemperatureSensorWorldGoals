using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public interface ICommunicatorActions
    {
        bool CreateRoom(IRoom room);

        bool RegisterSensor(ISensor sensor);

        bool CreateSensorReading(string roomUUID,ISensorReading sensorReading);

      }
}
