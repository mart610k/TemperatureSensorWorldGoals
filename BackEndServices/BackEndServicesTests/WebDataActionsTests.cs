using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Extras.Moq;
using BackEndServices.Database;
using BackEndServices.Sensor;
using Moq;
using NUnit.Framework;


namespace BackEndServicesTests
{
    class WebDataActionsTests
    {
        [Test]
        public void CheckGetLimitFromRoomCalledOnce()
        {
            string roomuuid = "b94df17e-d109-4e99-97c9-591a51529f85";
            int sensorTypeID = 1;
            string sqlStatement = "Select SensorTypeID,hex(SensorID),UpperLimit,LowerLimit from CustomSensorLimit where SensorID = unhex(\"" + roomuuid + "\") and SensorTypeID = " + sensorTypeID + ";";

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.GetSensorForLimitForRoom(roomuuid,sensorTypeID))
                    .Returns(GetSampleLimit()[0]);

                WebDataActions cls = mock.Create<WebDataActions>();

                ISensorLimit expected = GetSampleLimit()[0];
                ISensorLimit actual = cls.GetSensorLimitForRoom(roomuuid, sensorTypeID);

                mock.Mock<IDatabaseAccess>().Verify(x => x.GetSensorForLimitForRoom(roomuuid, sensorTypeID), Times.Exactly(1));

                Assert.AreEqual(expected.SensorID, actual.SensorID);
                Assert.AreEqual(expected.SensorName, actual.SensorName);
                Assert.AreEqual(expected.LowerLimit, actual.LowerLimit);
                Assert.AreEqual(expected.UpperLimit, actual.UpperLimit);
            }
        }
        [Test]
        public void CheckGetSensorReadingsCalledOnce()
        {
            string roomuuid = "b94df17e-d109-4e99-97c9-591a51529f85";
            int sensorTypeID = 1;
            int count = 3;
            string sqlStatement = "Select hex(SensorID),SensorTypeID,TimeRead,ValueRead from SensorReading where SensorID = unhex(\""+ roomuuid +"\") and SensorTypeID = "+sensorTypeID +" Limit "+ count;

            using (AutoMock mock = AutoMock.GetStrict())
            {
                mock.Mock<IDatabaseAccess>()
                    .Setup(x => x.GetSensorReadings(roomuuid,sensorTypeID,count))
                    .Returns(GetSampleReadings().ToArray());

                WebDataActions cls = mock.Create<WebDataActions>();

                List<ISensorReading> expected = GetSampleReadings();
                List<ISensorReading> actual = cls.GetSensorReadings(roomuuid, sensorTypeID,count).ToList();

                mock.Mock<IDatabaseAccess>().Verify(x => x.GetSensorReadings(roomuuid, sensorTypeID, count), Times.Exactly(1));

                Assert.AreEqual(expected.Count, actual.Count);
            }
        }


        private List<ISensorReading> GetSampleReadings()
        {
            return new List<ISensorReading>
            {
                new SensorReading(1,"b94df17e-d109-4e99-97c9-591a51529f85",DateTime.Now,10.00f),
                new SensorReading(1,"b94df17e-d109-4e99-97c9-591a51529f85",DateTime.Now,15.00f),
                new SensorReading(1,"b94df17e-d109-4e99-97c9-591a51529f85",DateTime.Now,12.00f)
            };
        }


        private List<ISensorLimit> GetSampleLimit()
        {
            return new List<ISensorLimit> { new SensorLimit(1, "Temperature", 10.00f, 30.00f) };
        }
    }

    
}
