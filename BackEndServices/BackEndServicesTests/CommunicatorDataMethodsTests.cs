using Autofac.Extras.Moq;
using BackEndServices.Database;
using BackEndServices.Room;
using BackEndServices.Sensor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndServicesTests
{
    class CommunicatorDataMethodsTests
    {
        

       

        [Test]
        public void CheckCreateRoomIsCalledOnce()
        {
            IRoom roomToTest = new Room("Room1", "9d203ee6-2651-458a-8d7b-9eda0496d962", "FF:FF:FF:FF:FF:FF", "192.168.1.1","");
            string sqlStatement = 
                "Insert Into Sensor(ID,Name,MacAddress,IPAddress,Description) " +
                "value (" +
                "hex(\"" + roomToTest.GUID.ToString() + "\")," +
                "\"" + roomToTest.Name + "\"," +
                "hex(\"" + roomToTest.MACAddress + "\")," +
                "\""+ roomToTest.IPAddress +"\"," +
                "\""+roomToTest.Description +"\"" +
                ");";

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.SaveData<bool>(sqlStatement))
                    .Returns(true);

                CommunicatorActions cls = mock.Create<CommunicatorActions>();

                bool expected = true;
                bool actual = cls.CreateRoom(roomToTest);

                mock.Mock<IDatabaseAccess>().Verify(x => x.SaveData<bool>(sqlStatement), Times.Exactly(1));

                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void RegisterSensorIsCalledOnce()
        {
            ISensor sensor = new Sensor(1, "Temperature");
            string sqlStatement = string.Format("Insert Into SensorType(ID,SensorName) value ({0},\"{1}\");",sensor.SensorID,sensor.SensorName);

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.SaveData<bool>(sqlStatement))
                    .Returns(true);

                CommunicatorActions cls = mock.Create<CommunicatorActions>();

                bool expected = true;
                bool actual = cls.RegisterSensor(sensor);

                mock.Mock<IDatabaseAccess>().Verify(x => x.SaveData<bool>(sqlStatement), Times.Exactly(1));

                Assert.AreEqual(expected, actual);

            }
        }

        [Test]
        public void CreateSensorReadingIsCalledOnce()
        {

            string roomID = "c4cd1535-5e40-4df8-a7ac-b43c7cd7816b";
            DateTime dateTime = DateTime.UtcNow;
            ISensorReading sensorReading = new SensorReading(1, "Temperature", dateTime, 15.23f);
            string sqlStatement = string.Format("Insert into SensorReading(SensorID,SensorTypeID,TimeRead,ValueRead) " +
                "value (hex(\"{0}\"),{1},{2},{3});",roomID,sensorReading.SensorID,sensorReading.TimeRead, sensorReading.ValueRead);


            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.SaveData<bool>(sqlStatement))
                    .Returns(true);

                CommunicatorActions cls = mock.Create<CommunicatorActions>();

                bool expected = true;
                bool actual = cls.CreateSensorReading(roomID, sensorReading);

                mock.Mock<IDatabaseAccess>().Verify(x => x.SaveData<bool>(sqlStatement), Times.Exactly(1));

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
