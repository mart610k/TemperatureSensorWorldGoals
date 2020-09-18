using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Sensor
{
    public interface ISensorLimit : ISensor
    {
        float LowerLimit { get; }

        float UpperLimit { get; } 
    }
}
