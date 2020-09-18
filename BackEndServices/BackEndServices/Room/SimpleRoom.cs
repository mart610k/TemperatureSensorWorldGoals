using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public class SimpleRoom : ISimpleRoom
    {
        public string Name { private set; get; }

        public Guid GUID { private set; get; }

        public SimpleRoom(string name, string guid)
        {
            Name = name;

            GUID = Guid.Parse(guid);
        }
    }
}
