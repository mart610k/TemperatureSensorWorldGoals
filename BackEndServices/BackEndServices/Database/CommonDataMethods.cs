using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    public class CommonDataMethods : ICommonDataMethods
    {
        protected IDatabaseAccess DatabaseAccess { get; set; }


        public CommonDataMethods(IDatabaseAccess databaseAccess)
        {
            DatabaseAccess = databaseAccess;
        }

        public ISimpleRoom[] GetRooms()
        {
            return DatabaseAccess.GetRooms();
        }

        public IRoom GetRoomDetailed(string roomDetailed)
        {
            return DatabaseAccess.GetDetailedRoom(roomDetailed);
        }

        public bool UpdateRoom(IRoom room)
        {
            return DatabaseAccess.UpdateRoom(room);
        }

        public ISensor[] GetSensorsForRoom(string roomUUID)
        {
            return DatabaseAccess.GetSensorsForRoom(roomUUID);
        }

        public ISensor[] GetAllSensors()
        {
            return DatabaseAccess.GetSensors();
        }
    }
}
