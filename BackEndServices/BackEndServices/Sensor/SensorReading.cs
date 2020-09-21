using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
    public class SensorReading : Sensor, ISensorReading
    {
        public DateTime TimeRead { private set; get; }

        public float ValueRead { private set; get; }


        public SensorReading(int sensorID, string sensorName,DateTime timeRead, float valueRead) : base(sensorID, sensorName)
        {
            TimeRead = timeRead;
            ValueRead = valueRead;
        }

        


    }
}
