using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    // on /org/bluez/hciX
    [Interface("org.bluez.MediaEndpoint1")]
    public interface MediaEndpoint1
    {
        void SetConfiguration(ObjectPath transport, IDictionary<string,object> properties);
		byte[] SelectConfiguration(byte[] capabilities);
		void ClearConfiguration(ObjectPath transport);
        void Release();
    }
}