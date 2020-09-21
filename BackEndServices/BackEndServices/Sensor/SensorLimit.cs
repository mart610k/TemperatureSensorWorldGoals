using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
    public class SensorLimit : Sensor, ISensorLimit
    {
        public float LowerLimit { get; private set; }

        public float UpperLimit { get; private set; }


        public SensorLimit(int sensorID, string sensorName,float lowerLimit,float upperLimit) : base(sensorID, sensorName)
        {
            LowerLimit = lowerLimit;

            UpperLimit = upperLimit;
        }

    }
}
