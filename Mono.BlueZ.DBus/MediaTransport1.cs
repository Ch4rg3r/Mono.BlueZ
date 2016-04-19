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
		FileDescriptor TryAcquire();
        void Release();
        ObjectPath Device {get;}
        string UUID {get;}
	    byte Codec {get;}
        byte[] Configuration {get;}
        State State {get;}
        ushort Delay {get;set;}
        ushort Volume {get;set;}
    }

    public enum State
    {
        Idle,
        Pending,
        Active
    }
}
