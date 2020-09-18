using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
   public class Sensor : ISensor
    {
        public int SensorID => throw new NotImplementedException();

        public string SensorName => throw new NotImplementedException();


        public Sensor(int sensorID,string sensorName)
        {

        }
    }
}
