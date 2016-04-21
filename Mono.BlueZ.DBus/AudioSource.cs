using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    [Interface("org.bluez.AudioSource")]
    public interface AudioSource
    {
        void Connect();
        void Disconnect();
        IDictionary<string, object> GetProperties();
        event PropertyChangedHandler PropertyChanged;
        string State { get; }
    }
}
