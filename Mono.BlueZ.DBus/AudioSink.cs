using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    [Interface("org.bluez.AudioSink")]
    public interface AudioSink
    {
        void Connect();
        void Disconnect();
        IDictionary<string, object> GetProperties();
        event PropertyChangedHandler PropertyChanged;
        string State { get; }
        bool Playing { get; }
    }
}
