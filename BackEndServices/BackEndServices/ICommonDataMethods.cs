using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices
{
    public interface ICommonDataMethods
    {
        ISimpleRoom[] GetRooms();

        IRoom GetRoomDetailed(string roomDetailed);

        bool UpdateRoom(IRoom room);

        ISensor[] GetSensorsForRoom(string roomUUID);

        ISensor[] GetAllSensors();


    }
}
