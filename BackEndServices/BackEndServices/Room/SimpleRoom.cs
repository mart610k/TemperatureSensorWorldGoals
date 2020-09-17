using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public class SimpleRoom : ISimpleRoom
    {
        public string Name => throw new NotImplementedException();

        public Guid GUID => throw new NotImplementedException();

        public SimpleRoom(string name, string guid)
        {

        }
    }
}
