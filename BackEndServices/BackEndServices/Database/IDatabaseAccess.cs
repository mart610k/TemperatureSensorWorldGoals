using BackEndServices.Room;
using BackEndServices.Sensor;
using System.Collections.Generic;

namespace BackEndServices.Database
{
    public interface IDatabaseAccess
    {
        ISimpleRoom[] GetRooms();

        IRoom GetDetailedRoom(string roomuuid);

        bool UpdateRoom(IRoom room);

        ISensor[] GetSensorsForRoom(string roomuuid);
        ISensor[] GetSensors();

        bool CreateRoom(IRoom room);

        bool RegisterSensor(ISensor sensor);
        bool CreateSensorReading(string roomUUID, ISensorReading sensorReading);
        ISensorLimit GetSensorForLimitForRoom(string roomuuid, int sensorTypeID);
        ISensorReading[] GetSensorReadings(string roomuuid, int sensorTypeID, int count );

        bool SetSensorLimitForRoom(string roomuuid, ISensorLimit sensorLimit);

        ISensor GetSensorByName(string sensorName);
    }
}
