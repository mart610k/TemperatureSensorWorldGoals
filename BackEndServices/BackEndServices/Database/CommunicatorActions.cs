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
            return DatabaseAccess.SaveData<bool>(string.Format("Insert Into Sensor(ID,Name,MacAddress,IPAddress,Description) " +
                "value (" +
                "unhex(\"{0}\")," +
                "\"{1}\"," +
                "unhex(\"{2}\")," +
                "\"{3}\"," +
                "\"{4}\"" +
                ");"
                ,room.GUID.ToString(),
                room.Name,
                room.MACAddress,
                room.IPaddress,
                room.Description));
        }

        public bool CreateSensorReading(string roomUUID, ISensorReading sensorReading)
        {

            return DatabaseAccess.SaveData<bool>(string.Format("Insert into SensorReading(SensorID,SensorTypeID,TimeRead,ValueRead) value (unhex(\"{0}\"),{1},{2},{3});", roomUUID,sensorReading.SensorID,sensorReading.TimeRead,sensorReading.ValueRead));
        }

        public bool RegisterSensor(ISensor sensor)
        {
            return DatabaseAccess.SaveData<bool>(string.Format("Insert Into SensorType(ID,SensorName) value ({0},\"{1}\");", sensor.SensorID, sensor.SensorName));
        }
    }
}
