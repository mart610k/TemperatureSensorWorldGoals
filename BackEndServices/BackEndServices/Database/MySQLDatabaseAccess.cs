using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Database
{
    class MySQLDatabaseAccess : IDatabaseAccess
    {
        public string Host { get; private set; }
        protected string UserName { get; private set; }
        protected string UserPassword { get; private set; }

        public string DatabaseName { get; private set; }

        public MySQLDatabaseAccess(string host, string databaseName, string userName, string userpassword)
        {
            Host = host;
            UserName = userName;
            UserPassword = userpassword;
            DatabaseName = databaseName;
        }
        
        private string GetConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3};",Host,DatabaseName,UserName,UserPassword);
        }


        public bool CreateRoom(IRoom room)
        {
            throw new NotImplementedException();
        }

        public bool CreateSensorReading(string roomUUID, ISensorReading sensorReading)
        {
            throw new NotImplementedException();
        }

        public IRoom GetDetailedRoom(string roomuuid)
        {
            throw new NotImplementedException();
        }

        public ISimpleRoom[] GetRooms()
        {
            throw new NotImplementedException();
        }

        public ISensorLimit GetSensorForLimitForRoom(string roomuuid, int sensorTypeID)
        {
            throw new NotImplementedException();
        }

        public ISensorReading[] GetSensorReadings(string roomuuid, int sensorTypeID, int count)
        {
            throw new NotImplementedException();
        }

        public ISensor[] GetSensors()
        {
            throw new NotImplementedException();
        }

        public ISensor[] GetSensorsForRoom(string roomuuid)
        {
            throw new NotImplementedException();
        }

        public bool RegisterSensor(ISensor sensor)
        {
            throw new NotImplementedException();
        }

        public bool SetSensorLimitForRoom(string roomuuid, ISensorLimit sensorLimit)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoom(IRoom room)
        {
            throw new NotImplementedException();
        }
    }
}
