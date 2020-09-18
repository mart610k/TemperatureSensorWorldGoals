using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public interface IRoom : ISimpleRoom
    {
        string MACAddress { get; }

        string IPAddress { get; }

        string Description { get; }

    }
}
