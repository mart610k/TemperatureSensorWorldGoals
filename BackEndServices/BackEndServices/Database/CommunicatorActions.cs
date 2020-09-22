using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public class CommunicatorActions : CommonDataMethods, ICommunicatorActions
    {
        public CommunicatorActions(IDatabaseAccess databaseAccess) : base(databaseAccess) { }

        public bool CreateRoom(IRoom room)
        {
            return DatabaseAccess.CreateRoom(room);
        }

        public bool CreateSensorReading(string roomUUID, ISensorReading sensorReading)
        {
            return DatabaseAccess.CreateSensorReading(roomUUID,sensorReading);
        }

        public bool RegisterSensor(ISensor sensor)
        {
            return DatabaseAccess.RegisterSensor(sensor);
        }
    }
}
