using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices
{
    public class CommonDataMethods : ICommonDataMethods
    {
        IDatabaseAccess DatabaseAccess { get; set; }


        public CommonDataMethods(IDatabaseAccess databaseAccess)
        {
            DatabaseAccess = databaseAccess;
        }

        public ISimpleRoom[] GetRooms()
        {
            throw new NotImplementedException();
        }

        public IRoom GetRoomDetailed(string roomDetailed)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoom(IRoom room)
        {
            throw new NotImplementedException();
        }

        public ISensor[] GetSensorsForRoom(string roomUUID)
        {
            throw new NotImplementedException();
        }

        public ISensor[] GetAllSensors()
        {
            throw new NotImplementedException();
        }
    }
}
