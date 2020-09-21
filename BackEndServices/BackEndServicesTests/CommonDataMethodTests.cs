using Autofac.Extras.Moq;

using BackEndServices.Database;
using BackEndServices.Room;
using BackEndServices.Sensor;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BackEndServicesTests
{
    public class CommonDataMethodTests
    {
        [Test]
        public void CheckGetRoomsOnlyCallsGetDataOnce()
        {
            using (AutoMock mock = AutoMock.GetStrict())
            {
                string sqlStatement = "Select hex(ID),Name from Sensor;";

                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.LoadData<ISimpleRoom>(sqlStatement))
                    .Returns(GetSampleRooms());

                CommonDataMethods cls = mock.Create<CommonDataMethods>();

                List<ISimpleRoom> expected = GetSampleRooms();
                List<ISimpleRoom> actual = cls.GetRooms().ToList();
                
                mock.Mock<IDatabaseAccess>().Verify(x => x.LoadData<ISimpleRoom>(sqlStatement),Times.Exactly(1));

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }
        [Test]
        public void CheckGetRoomsCallsGetRoomsAndRetrievesData()
        {
            using (AutoMock mock = AutoMock.GetStrict())
            {
                string sqlStatement = "Select hex(ID),Name from Sensor;";

                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.LoadData<ISimpleRoom>(sqlStatement))
                    .Returns(GetSampleRooms());

                CommonDataMethods cls = mock.Create<CommonDataMethods>();


                List<ISimpleRoom> expected = GetSampleRooms();
                List<ISimpleRoom> actual = cls.GetRooms().ToList();

                mock.Mock<IDatabaseAccess>().Verify(x => x.LoadData<ISimpleRoom>(sqlStatement), Times.Exactly(1));

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [Test]
        public void CheckDetailedRoomIsReturned()
        {

            string roomUUID = "8de8e4bc-1754-4e10-a3e5-7e535a5559a1";
            using (AutoMock mock = AutoMock.GetStrict())
            {
                string sqlStatement = "Select unhex(ID),Name,unhex(MacAdress),IpAddress,Description from Sensor where ID = hex(\""+ roomUUID + "\");";

                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.LoadData<IRoom>(sqlStatement))
                    .Returns(new List<IRoom> { GetSampleRoom() });

                CommonDataMethods cls = mock.Create<CommonDataMethods>();


                IRoom expected = GetSampleRoom();
                IRoom actual = cls.GetRoomDetailed(roomUUID);

                mock.Mock<IDatabaseAccess>().Verify(x => x.LoadData<ISimpleRoom>(sqlStatement), Times.Exactly(1));

                Assert.True(actual != null);
                Assert.AreEqual(expected.GUID.ToString(),actual.GUID.ToString());
            }
        }

        [Test]
        public void CheckUpdateRoomIsCalledOnce()
        {
            IRoom room = GetSampleRoom();
            string sqlStatement = "Update Sensor set " +
                    "Name = \"" + room.Name + "\"," +
                    "MacAddress = hex(\"" + room.MACAddress + "\")," +
                    "IpAddress = \"" + room.IPaddress + "\", " +
                    "Description = \"" + room.Description + "\" " +
                    "WHERE ID = unhex(\"" + room.GUID.ToString() + "\");";

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.UpdateData<bool>(sqlStatement))
                    .Returns(true);

                CommonDataMethods cls = mock.Create<CommonDataMethods>();

                bool expected = true;
                bool actual = cls.UpdateRoom(room);

                mock.Mock<IDatabaseAccess>().Verify(x => x.UpdateData<bool>(sqlStatement), Times.Exactly(1));

                Assert.True(actual != false);
                Assert.AreEqual(expected,actual);
            }
        }
        [Test]
        public void CheckGetSensorsForRoomIsCalledOnce()
        {
            IRoom room = GetSampleRoom();

            string sqlStatement = "Select ID, SensorName From SensorType Where ID in (Select SensorTypeID where SensorID = unhex(\"" + room.GUID.ToString() + "\"))";

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.LoadData<ISensor>(sqlStatement))
                    .Returns(GetSampleSensors());

                CommonDataMethods cls = mock.Create<CommonDataMethods>();

                List<ISensor> expected = GetSampleSensors();
                List<ISensor> actual = cls.GetSensorsForRoom(room.GUID.ToString()).ToList();

                mock.Mock<IDatabaseAccess>().Verify(x => x.LoadData<ISensor>(sqlStatement), Times.Exactly(1));

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [Test]
        public void CheckGetAllSensorsAreCalledOnce()
        {
            string sqlStatement = "Select ID,SensorName From SensorType;";

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.LoadData<ISensor>(sqlStatement))
                    .Returns(GetSampleSensors());

                CommonDataMethods cls = mock.Create<CommonDataMethods>();

                List<ISensor> expected = GetSampleSensors();
                List<ISensor> actual = cls.GetAllSensors().ToList();

                mock.Mock<IDatabaseAccess>().Verify(x => x.LoadData<ISensor>(sqlStatement), Times.Exactly(1));

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        private List<ISimpleRoom> GetSampleRooms()
        {
            List<ISimpleRoom> list = new List<ISimpleRoom>
            {
                new SimpleRoom("test1", "76b5e248-ad4e-4c52-a6b9-e07b237ef704"),
                new SimpleRoom("test2", "f0c48bf8-1ba9-4c18-9618-eff4941f1a65")
            };

            return list;
        }

        private List<ISensor> GetSampleSensors()
        {
            List<ISensor> sensors = new List<ISensor>()
            {
                new Sensor(1,"Temperature"),
                new Sensor(2,"Humidity")
            };
            return sensors;
        }


        private IRoom GetSampleRoom()
        {
            return new Room("RoomA3", "8de8e4bc-1754-4e10-a3e5-7e535a5559a1","ff-ff-ff-ff-ff-ff","123.123.123.132","test");
        }
    }
}