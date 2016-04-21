using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.BlueZ.DBus;
using Mono.BlueZ;
using DBus;

namespace Mono.BlueZ.Console
{
    public class Endpoint : MediaEndpoint1
    {
        private ObjectPath transportPath;

        public void ClearConfiguration(ObjectPath transport)//B2. Device Disconnection Events
        {
            transportPath = null;
            return;
        }

        public void Release()
        {
            return;
        }

        public byte[] SelectConfiguration(byte[] capabilities)//B1. Device Connection Events
        {
            if(capabilities == A2DP.MP3_CAPABILITIES)
            {
                return A2DP.MP3_CONFIGURATION;
            }
            if(capabilities == A2DP.SBC_CAPABILITIES)
            {
                return A2DP.SBC_CONFIGURATION;
            }
            return null;
        }

        public void SetConfiguration(ObjectPath transport, IDictionary<string, object> properties)//B1. Device Connection Events
        {
            transportPath = transport;
            return;
        }

        public ObjectPath TransportPath
        {
            get { return transportPath; }
        }
    }
}
