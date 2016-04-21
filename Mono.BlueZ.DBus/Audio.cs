using System;
using System.Collections.Generic;
using DBus;

namespace Mono.BlueZ.DBus
{
    public delegate void PropertyChangedHandler(string name, object value);

    public static class AudioState
    {
        public const string Disconnected = "disconnected";
        public const string Connected = "connected";
        public const string Connecting = "connecting";
        public const string Playing = "playing";
    }
}
