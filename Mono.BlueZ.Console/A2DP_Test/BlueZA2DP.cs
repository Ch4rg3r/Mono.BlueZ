using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBus;
using org.freedesktop.DBus;
using Mono.BlueZ;
using Mono.BlueZ.DBus;
using System.Threading;

namespace Mono.BlueZ.Console
{
    public class BlueZA2DP
    {
        private Bus _system;
        public Exception _startupException { get; private set; }
        private ManualResetEvent _started = new ManualResetEvent(false);

        private const string BlueZRootPath = "/org/bluez";
        private const string BlueZService = "org.bluez";

        private ObjectPath ProfilePath = new ObjectPath("/profiles");
        private ObjectPath EndpointPath = new ObjectPath("/led_web/endpoint");
        private ObjectPath BlueZPath = new ObjectPath("/org/bluez");

        private ObjectManager _objectManager;
        private AgentManager1 _agentManager;
        private ProfileManager1 _profileManager;

        private Endpoint _endpoint;
        private FileDescriptor _filedescriptor;

        public BlueZA2DP()
        {
            var t = new Thread(DBusLoop);
            t.IsBackground = true;
            t.Start();
            _started.WaitOne(60 * 1000);
            _started.Close();
            if (_startupException != null)
            {
                throw _startupException;
            }
            else
            {
                _objectManager = _system.GetObject<org.freedesktop.DBus.ObjectManager>(BlueZService, ObjectPath.Root);
                _objectManager.InterfacesAdded += _objectManager_InterfacesAdded;
                _objectManager.InterfacesRemoved += _objectManager_InterfacesRemoved;
            }
        }

        public void RegisterEndpoint()//A1. Application Startup
        {
            var adapter = BlueZUtils.find_adapter();
            var path = adapter.Key;

            var media = _system.GetObject<Media1>(BlueZService, path);
            //_endpoint = _system.GetObject<MediaEndpoint1>(BlueZService, ObjectPath.Root);
            _endpoint = new Endpoint();

            _system.Register(EndpointPath, _endpoint);
            media.RegisterEndpoint(EndpointPath, A2DP.MP3_SINK_PROPERTIES);

            var audiosource = _system.GetObject<AudioSource>(BlueZService, ObjectPath.Root);
            audiosource.PropertyChanged += AudioSourcePropertyChanged;
        }

        private void GetTransportStream()
        {
            ObjectPath transportPath = _endpoint.TransportPath;
            var transport = _system.GetObject<MediaTransport1>(BlueZService, transportPath);

            _filedescriptor = transport.Acquire();
        }

        public FileDescriptor AudioStream
        {
            get { return _filedescriptor; }
        }

        private void _objectManager_InterfacesRemoved(ObjectPath path, string[] interfaces)
        {
        }

        private void _objectManager_InterfacesAdded(ObjectPath path, IDictionary<string, IDictionary<string, object>> interfaces)
        {
        }

        private void AudioSourcePropertyChanged(string name, object value)//C1. Start streaming event. 
        {
            if (name == "State")
            {
                switch (value as string)
                {
                    case AudioState.Playing:
                        GetTransportStream();
                        break;
                    //TODO implement changes to stop stream
                }
            }
        }

        private void DBusLoop()
        {
            try
            {
                _system = Bus.System;
            }
            catch (Exception ex)
            {
                _startupException = ex;
                return;
            }
            finally
            {
                _started.Set();
            }

            while (true)
            {
                _system.Iterate();
            }
        }

        private ProfileManager1 ProfileManager
        {
            get
            {
                if (_profileManager == null)
                {
                    _profileManager = _system.GetObject<ProfileManager1>(BlueZService, new ObjectPath(BlueZRootPath));
                }
                return _profileManager;
            }
        }

        private ObjectPath GetObjectPathForLocalObject(object obj)
        {
            return new ObjectPath("/" + obj.GetHashCode());
        }
    }
}
