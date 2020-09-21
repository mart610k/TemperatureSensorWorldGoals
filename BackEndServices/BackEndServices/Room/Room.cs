using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace BackEndServices.Room
{
    public class Room : SimpleRoom, IRoom
    {

        public Room(string name, string guid, string macAddress, string ipAddress, string description) : base(name, guid)
        {
            macAddress = macAddress.ToUpper().Replace("-", "");


            if (Regex.IsMatch(macAddress, @"\b[0-F]{12}\b"))
            {
                MACAddress = macAddress;
            }
            else if (macAddress.Length != 12)
            {
                throw new ArgumentException("Needs to be 12 without seperators", "macAddress");
            }
            else if (Regex.IsMatch(macAddress, @"[^0-F]"))
            {
                throw new ArgumentException("Allowed caracters are 0-9 and A-F", "macAddress");
            }
            else
            {
                throw new Exception("Unknown Error have accurred while checking ");
            }
            try
            {
                IPAddress.Parse(ipAddress);
            }
            catch
            {
                throw new ArgumentException("Address was either illigal or out of range", "ipAddress");
            }
            IPaddress = ipAddress;

            Description = description;
        }

        public string MACAddress { private set; get; }

        public string IPaddress { private set; get; }

        public string Description { private set; get; }
    }
}
