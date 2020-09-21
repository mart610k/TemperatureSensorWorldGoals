﻿using BackEndServices.Room;
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
            return DatabaseAccess.LoadData<ISimpleRoom>("Select hex(ID),Name from Sensor;").ToArray();
        }

        public IRoom GetRoomDetailed(string roomDetailed)
        {
            return DatabaseAccess.LoadData<IRoom>("Select unhex(ID),Name,unhex(MacAdress),IpAddress,Description from Sensor where ID = hex(\"" + roomDetailed + "\");")[0];
        }

        public bool UpdateRoom(IRoom room)
        {
            return DatabaseAccess.UpdateData<bool>("Update Sensor set " +
            "Name = \"" + room.Name + "\"," +
            "MacAddress = hex(\"" + room.MACAddress + "\")," +
            "IpAddress = \"" + room.IPaddress + "\", " +
            "Description = \"" + room.Description + "\" " +
            "WHERE ID = unhex(\"" + room.GUID.ToString() + "\");");
        }

        public ISensor[] GetSensorsForRoom(string roomUUID)
        {
            return DatabaseAccess.LoadData<ISensor>("Select ID, SensorName From SensorType Where ID in (Select SensorTypeID where SensorID = unhex(\"" + roomUUID + "\"))").ToArray();
        }

        public ISensor[] GetAllSensors()
        {
            return DatabaseAccess.LoadData<ISensor>("Select ID,SensorName From SensorType;").ToArray();
        }
    }
}
