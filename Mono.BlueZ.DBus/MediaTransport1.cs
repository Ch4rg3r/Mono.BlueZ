using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    // on /org/bluez/hciX
    [Interface("org.bluez.MediaEndpoint1")]
    public interface MediaEndpoint1
    {
        FileDescriptor Acquire();
		FileDescriptor TryAcquire();
        void Release();
        readonly ObjectPath Device;
        readonly string UUID;
		readonly byte Codec ;
        readonly byte[] Configuration;
        readonly State State;
        ushort Delay {get;set;}
        ushort Volume {get;set;}
    }

    public enum State
    {
        Idle = "idle",
        Pending = "pending",
        Active = "active"
    }
}