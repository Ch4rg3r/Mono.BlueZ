using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    // on /org/bluez/hciX
    [Interface("org.bluez.MediaTransport1")]
    public interface MediaTransport1
    {
        FileDescriptor Acquire();
        //TODO fd, uint16, uint16 Acquire() "Acquire transport file descriptor and the MTU for readand write respectively."
        FileDescriptor TryAcquire();
        //TODO fd, uint16, uint16 TryAcquire() 
        void Release();
        ObjectPath Device {get;}
        string UUID {get;}
	    byte Codec {get;}
        byte[] Configuration {get;}
        string State {get;}
        ushort Delay {get;set;}
        ushort Volume {get;set;}
    }

    public static class TransportState
    {
        public const string Idle = "idle";
        public const string Pending = "pending";
        public const string Active = "active";
    }
}
