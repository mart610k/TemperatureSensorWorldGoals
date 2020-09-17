using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public interface IRoom : ISimpleRoom
    {
        string MACAddress { get; }

        string IPAddresss { get; }

        string Description { get; } 

    }
}
