using System;
using System.Collections.Generic;
using System.Text;
using BackEndServices.Room;
using NUnit.Framework;

namespace BackEndServicesTests
{
    class ConstructorInputHandlesInputAsExpected
    {
        [TestCase("aeaa")]
        [TestCase("aeaaaeaaaeaaaeaaaeaa")]
        public void MacAddressTooLongOrShort(string macToTest)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate 
                { IRoom test = new Room("Test", "4205be2e-65f2-4bb8-a673-aa645ab54d4e", macToTest, "123.132.14.12", ""); }
                );
            Assert.True(ex.Message.Contains("Needs to be 12 without seperators"));
            Assert.AreEqual("macAddress", ex.ParamName);

        }
        [Test]
        public void MacAddressContainsIlligalCharacters()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate
                {
                    IRoom room = new Room("Test", "4205be2e-65f2-4bb8-a673-aa645ab54d4e", "12345678901p", "123.132.14.12", "");
                }

                );
            Assert.True(ex.Message.Contains("Allowed caracters are 0-9 and A-F"));
            Assert.AreEqual(ex.ParamName, "macAddress");
        }

        [Test]
        public void MacAddressAreParsedWithSeperatorUpperCase()
        {
            string mac = "01-23-45-67-89-AF";
            IRoom room = null;
            Assert.DoesNotThrow(
                delegate { room = new Room("Test", "4205be2e-65f2-4bb8-a673-aa645ab54d4e", mac, "123.132.14.12", ""); }
                );
            string expected = mac.Replace("-", "");
            Assert.AreEqual(expected, room.MACAddress);
        }


        [Test]
        public void MacAddressAreParsedWithSeperatorLowerCase()
        {
            string mac = "01-23-45-67-89-ab";
            IRoom room = null;
            Assert.DoesNotThrow(
                delegate { room = new Room("Test", "4205be2e-65f2-4bb8-a673-aa645ab54d4e", mac, "123.132.14.12", ""); }
                );
            string expected = mac.Replace("-", "").ToUpper();
            Assert.AreEqual(expected, room.MACAddress);
        }
        [Test]
        public void IPAddressThrowsWhenIPIsInvalid()
        {
            string ipaddress = "256.11.11.11";
            IRoom room = null;

            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { room = new Room("Test", "4205be2e-65f2-4bb8-a673-aa645ab54d4e", "01-23-45-67-89-ab", ipaddress, ""); }
                );
            Assert.True(ex.Message.Contains("Address was either illigal or out of range"));
            Assert.AreEqual(ex.ParamName, "ipAddress");
        }


    }
}
