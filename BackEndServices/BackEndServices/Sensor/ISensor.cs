using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
    public interface ISensor
    {
        int SensorID { get; }

        string SensorName { get; }
    }
}
