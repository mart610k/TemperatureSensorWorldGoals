using Autofac.Extras.Moq;
using BackEndServices;
using BackEndServices.Room;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BackEndServicesTests
{
    public class RoomMethodsCommonDataMethods
    {
        [Test]
        public void CheckGetRoomsOnlyCallsGetDataOnce()
        {
            using (AutoMock mock = AutoMock.GetStrict())
            {
                string sqlStatement = "Select unhex(ID),Name from Sensor;";

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
                string sqlStatement = "Select unhex(ID),Name from Sensor;";

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


        private List<ISimpleRoom> GetSampleRooms()
        {
            List<ISimpleRoom> list = new List<ISimpleRoom>
            {
                new SimpleRoom("test1", "76b5e248-ad4e-4c52-a6b9-e07b237ef704"),
                new SimpleRoom("test2", "f0c48bf8-1ba9-4c18-9618-eff4941f1a65")
            };

            return list;
        }
        private IRoom GetSampleRoom()
        {
            

            return new Room("RoomA3", "8de8e4bc-1754-4e10-a3e5-7e535a5559a1","test","test","test");
        }
    }
}