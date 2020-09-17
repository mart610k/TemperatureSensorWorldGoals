using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
    public interface ISensorReading : ISensor
    {
        DateTime TimeRead { get; }
        
        float ValueRead { get; }


    }
}
