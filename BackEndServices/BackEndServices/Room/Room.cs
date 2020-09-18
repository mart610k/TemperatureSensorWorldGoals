using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public class Room : SimpleRoom, IRoom
    {

        public Room(string name, string guid, string macAddress, string ipAddress, string description) : base(name, guid)
        {
            MACAddress = macAddress;

            IPAddress = ipAddress;

            Description = description;
        }
        public string MACAddress { private set; get; }

        public string IPAddress { private set; get; }

        public string Description { private set; get; }
    }
}
