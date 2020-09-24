using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public interface ICommonDataMethods
    {
        ISimpleRoom[] GetRooms();

        IRoom GetRoomDetailed(string roomDetailed);

        bool UpdateRoom(IRoom room);

        ISensor[] GetSensorsForRoom(string roomUUID);

        ISensor[] GetAllSensors();

        ISensor GetSensorByName(string sensorName);


    }
}
