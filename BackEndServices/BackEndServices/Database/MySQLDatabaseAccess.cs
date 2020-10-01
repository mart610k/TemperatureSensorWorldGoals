using BackEndServices.Room;
using BackEndServices.Sensor;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace BackEndServices.Database
{
    public class MySQLDatabaseAccess : IDatabaseAccess
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
            return string.Format("Server={0}; Database={1}; Uid={2}; Pwd={3};",Host,DatabaseName,UserName,UserPassword);
        }

        public bool CreateRoom(IRoom room)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "INSERT INTO Sensor(ID,`Name`,Macaddress,IpAddress,`Description`) VALUE (UUID_TO_BIN(@UUID),@RoomName,UNHEX(@MacAddress),@IpAddress,@Description);";

            command.Parameters.AddWithValue("@UUID", room.GUID.ToString());
            command.Parameters.AddWithValue("@RoomName", room.Name);
            command.Parameters.AddWithValue("@MacAddress", room.MACAddress);
            command.Parameters.AddWithValue("@IpAddress", room.IPaddress);
            command.Parameters.AddWithValue("@Description", room.Description);

            conn.Open();

            int result = command.ExecuteNonQuery();
            
            conn.Close();

            if(result == 1)
            {
                return true;
            }
            return false;
            
        }


        public bool RegisterSensor(ISensor sensor)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "INSERT INTO SensorType(SensorName) VALUE (@SensorName);";
            command.Parameters.AddWithValue("@SensorName", sensor.SensorName);

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();

            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public IRoom GetDetailedRoom(string roomuuid)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT BIN_TO_UUID(ID),Name,HEX(MacAddress),IpAddress,Description FROM Sensor WHERE ID = UUID_TO_BIN(@UUID);";

            command.Parameters.AddWithValue("@UUID", roomuuid);

            conn.Open();

            MySqlDataReader reader = command.ExecuteReader();
            IRoom room = null;
            while(reader.Read())
            {
                room = new Room.Room(reader.GetString("Name"), reader.GetString("BIN_TO_UUID(ID)"), reader.GetString("HEX(MacAddress)"), reader.GetString("IpAddress"), reader.GetString("Description"));
            }

            return room;
        }

        public ISimpleRoom[] GetRooms()
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT BIN_TO_UUID(ID),Name FROM Sensor;";

            conn.Open();

            MySqlDataReader reader = command.ExecuteReader();
            List<ISimpleRoom> roomList = new List<ISimpleRoom>();
           
            while (reader.Read())
            {
                
                roomList.Add(new SimpleRoom(reader.GetString("Name"), reader.GetString("BIN_TO_UUID(ID)")));
            }

            reader.Close();
            conn.Close();

            return roomList.ToArray();
        }

        public ISensor[] GetSensors()
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT ID,SensorName FROM SensorType;";

            List<ISensor> sensors = new List<ISensor>();
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                sensors.Add(new Sensor.Sensor(reader.GetInt32("ID"), reader.GetString("SensorName")));

            }
            reader.Close();
            conn.Close();

            return sensors.ToArray();
        }

        public bool CreateSensorReading(string roomUUID, ISensorReading sensorReading)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "INSERT INTO SensorReading(SensorID,SensorTypeID,TimeRead,ValueRead) VALUE (UUID_TO_BIN(@UUID),@SensorID,@DateTime,@ValueRead);";
            command.Parameters.AddWithValue("@UUID", roomUUID);
            command.Parameters.AddWithValue("@SensorID", sensorReading.SensorID);
            command.Parameters.AddWithValue("@DateTime", sensorReading.TimeRead.ToString("yyyy-MM-dd H:mm:ss"));
            command.Parameters.AddWithValue("@ValueRead", sensorReading.ValueRead);

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();

            if(result == 1)
            {
                return true;
            }
            return false;
        }

        public ISensorReading[] GetSensorReadings(string roomuuid, int sensorTypeID, int count)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT " +
                "SensorReading.TimeRead,SensorReading.ValueRead,SensorReading.SensorTypeID,SensorType.SensorName " +
                "FROM SensorReading " +
                "JOIN SensorType ON SensorType.ID = SensorReading.SensorTypeID " +
                "WHERE SensorReading.SensorID = UUID_TO_BIN(@UUID) AND SensorReading.SensorTypeID = @SensorID " +
                "ORDER BY SensorReading.TimeRead DESC Limit @Count;";

            command.Parameters.AddWithValue("@UUID", roomuuid);
            command.Parameters.AddWithValue("@SensorID", sensorTypeID);
            command.Parameters.AddWithValue("@Count", count);
            List<ISensorReading> sensorReadings = new List<ISensorReading>();
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                sensorReadings.Add(new SensorReading(
                    reader.GetInt32("SensorTypeID"), 
                    reader.GetString("SensorName"), 
                    reader.GetDateTime("TimeRead"), 
                    reader.GetFloat("ValueRead")));
            }
            reader.Close();

            conn.Close();

            return sensorReadings.ToArray();
        }


        public bool SetSensorLimitForRoom(string roomuuid, ISensorLimit sensorLimit)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();


            command.CommandText = "INSERT INTO CustomSensorLimit(SensorTypeID,SensorID,UpperLimit,LowerLimit) " +
                "VALUE (@SensorTypeID,UUID_TO_BIN(@UUID),@UpperLimit,@LowerLimit);";

            command.Parameters.AddWithValue("@SensorTypeID", sensorLimit.SensorID);
            command.Parameters.AddWithValue("@UUID", roomuuid);
            command.Parameters.AddWithValue("@UpperLimit", sensorLimit.UpperLimit);
            command.Parameters.AddWithValue("@LowerLimit", sensorLimit.LowerLimit);

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();

            if(result == 1)
            {
                return true;
            }
            return false;
        }

        public ISensorLimit GetSensorForLimitForRoom(string roomuuid, int sensorTypeID)
        {
            //MySqlConnection conn = new MySqlConnection(GetConnectionString());
            //MySqlCommand command = conn.CreateCommand();
            throw new NotImplementedException();
        }

        


        public ISensor[] GetSensorsForRoom(string roomuuid)
        {

                 MySqlConnection conn = new MySqlConnection(GetConnectionString());

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "select SensorTypeID, SensorName from SensorReading join SensorType on SensorType.ID = SensorReading.SensorTypeID where SensorID = UUID_TO_BIN(@UUID) group by SensorTypeID;";


            command.Parameters.AddWithValue("@UUID", roomuuid);
            List<ISensor> sensors = new List<ISensor>();
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sensors.Add(new Sensor.Sensor(
                    reader.GetInt32("SensorTypeID"),
                    reader.GetString("SensorName")));
            }
            reader.Close();

            conn.Close();

            return sensors.ToArray();
        }



        public bool UpdateRoom(IRoom room)
        {
            throw new NotImplementedException();
        }

        public ISensor GetSensorByName(string sensorName)
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT ID,SensorName FROM SensorType WHERE SensorName LIKE @sensorName LIMIT 1;";
            command.Parameters.AddWithValue("@sensorName", sensorName);


            ISensor sensor = null;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                sensor = new Sensor.Sensor(reader.GetInt32("ID"), reader.GetString("SensorName"));
            }
            catch(Exception e)
            {
                throw e;
            }
            reader.Close();
            conn.Close();

            return sensor;
        }
    }
}
