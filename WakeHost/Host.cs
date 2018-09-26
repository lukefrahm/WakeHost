using System;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

namespace WakeHost
{
    [XmlRoot("Host", IsNullable = false)]
    internal sealed class Host
    {
        [XmlAttribute]
        internal string Name { get; set; }
        internal string FQDN { get; set; }
        internal byte[] IpAddress
        {
            get
            {
                return IpAddress;
            }
            set
            {
                IpAddress = IPAddress.Parse(value.ToString()).GetAddressBytes();
            }
        }
        [XmlArray]
        internal Interface[] MacAddresses { get; set; }
        
        internal Host()
        {

        }
    }

    internal class Interface
    {
        [XmlAttribute]
        internal byte Position { get; set; }
        internal byte[] MacAddress
        {
            get { return MacAddress; }
            set
            { 
                MacAddress = value.Length == 6 ? value : throw new ArgumentException("Invalid MAC address.");
            }
        }
    }
}
