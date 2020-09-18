using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
   public class Sensor : ISensor
    {
        public int SensorID { get; private set; }

        public string SensorName { get; private set; }


        public Sensor(int sensorID,string sensorName)
        {
            SensorID = sensorID;

            SensorName = sensorName;
        }
    }
}
