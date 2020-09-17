using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public class Room : SimpleRoom, IRoom
    {

        public Room(string name, string guid, string macAddress, string ipAddress, string description) : base(name, guid)
        {

        }
        public string MACAddress => throw new NotImplementedException();

        public string IPAddresss => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();
    }
}
