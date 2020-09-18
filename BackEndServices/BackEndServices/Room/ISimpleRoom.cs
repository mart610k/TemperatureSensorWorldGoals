using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices.Room
{
    public interface ISimpleRoom
    {
        string Name { get; }
        Guid GUID { get; }
    }
}
