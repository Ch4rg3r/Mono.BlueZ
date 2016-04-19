using System;
using System.Collections.Generic;

namespace Mono.BlueZ.DBus
{
    public static class A2DP
    {
        #region const
        public const string A2DP_SOURCE_UUID = "0000110A-0000-1000-8000-00805F9B34FB";
        public const string A2DP_SINK_UUID = "0000110B-0000-1000-8000-00805F9B34FB";
        public const string HFP_AG_UUID = "0000111F-0000-1000-8000-00805F9B34FB";
        public const string HFP_HF_UUID = "0000111E-0000-1000-8000-00805F9B34FB";
        public const string HSP_AG_UUID = "00001112-0000-1000-8000-00805F9B34FB";


        public const byte SBC_CODEC = 0;//dbus.Byte(0x00)
        //Channel Modes: Mono DualChannel Stereo JointStereo
        //Frequencies: 16Khz 32Khz 44.1Khz 48Khz
        //Subbands: 4 8
        //Blocks: 4 8 12 16
        //Bitpool Range: 2-64
        public static byte[] SBC_CAPABILITIES = new byte[] { 0xff, 0xff, 2, 64 };//dbus.Array([dbus.Byte(0xff), dbus.Byte(0xff), dbus.Byte(2), dbus.Byte(64)])
        //JointStereo 44.1Khz Subbands: Blocks: 16 Bitpool Range: 2-32
        public static byte[] SBC_CONFIGURATION = new byte[] { 0x21, 0x15, 2, 32 };//dbus.Array([dbus.Byte(0x21), dbus.Byte(0x15), dbus.Byte(2), dbus.Byte(32)])



        public const byte MP3_CODEC = 1;//dbus.Byte(0x01)
        //Channel Modes: Mono DualChannel Stereo JointStereo
        //Frequencies: 32Khz 44.1Khz 48Khz
        //CRC: YES
        //Layer: 3
        //Bit Rate: All except Free format
        //VBR: Yes
        //Payload Format: RFC-2250
        public static byte[] MP3_CAPABILITIES = new byte[] { 0x3f, 0x07, 0xff, 0xfe };//dbus.Array([dbus.Byte(0x3f), dbus.Byte(0x07), dbus.Byte(0xff), dbus.Byte(0xfe)])
        //JointStereo 44.1Khz Layer: 3 Bit Rate: VBR Format: RFC-2250
        public static byte[] MP3_CONFIGURATION = new byte[] { 0x21, 0x02, 0x00, 0x80 };//dbus.Array([dbus.Byte(0x21), dbus.Byte(0x02), dbus.Byte(0x00), dbus.Byte(0x80)])



        public const byte PCM_CODEC = 0;//dbus.Byte(0x00)
        //public static const PCM_CONFIGURATION = dbus.Array([], signature="ay")
        //TODO pcm config 

        public const byte CVSD_CODEC = 1;//dbus.Byte(0x01)
        #endregion

        #region Propterties
        public static IDictionary<string, object> SBC_SOURCE_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , A2DP_SOURCE_UUID},
            {"Codec" , SBC_CODEC},
            {"DelayReporting" , true},
            {"Capabilities" , SBC_CAPABILITIES}
        };

        public static IDictionary<string, object> SBC_SINK_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , A2DP_SINK_UUID},
            {"Codec" , SBC_CODEC},
            {"DelayReporting" , true},
            {"Capabilities" , SBC_CAPABILITIES}
        };

        public static IDictionary<string, object> MP3_SOURCE_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , A2DP_SOURCE_UUID},
            {"Codec" , MP3_CODEC},
            {"Capabilities" , MP3_CAPABILITIES}
        };

        public static IDictionary<string, object> MP3_SINK_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , A2DP_SINK_UUID},
            {"Codec" , MP3_CODEC},
            {"Capabilities" , MP3_CAPABILITIES}
        };

        //TODO based on PCM_CONF
        /*public static IDictionary<string, object> HFP_AG_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , HFP_AG_UUID},
            {"Codec" , PCM_CODEC},
            {"Capabilities" , PCM_CONFIGURATION}
        };

        public static IDictionary<string, object> HFP_HF_PROPERTIES = new Dictionary<string, object>
        { 
            {"UUID" , HFP_HF_UUID},
            {"Codec" , CVSD_CODEC},
            {"Capabilities" , PCM_CONFIGURATION}
        };*/
        #endregion
    }
}
