using System;
using System.Collections.Generic;
using DBus;
using Mono.BlueZ.DBus;

namespace Mono.Bluez
{
    //https://git.kernel.org/cgit/bluetooth/bluez.git/tree/test/bluezutils.py
    public static class BluezUtils//TODO Address pattern 
    {
        private const string ServiceName = "org.bluez";

        public static IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> get_managed_objects()
        {
            var bus = Bus.System;
            var manager = bus.GetObject<org.freedesktop.DBus.ObjectManager>(ServiceName, ObjectPath.Root);
            return manager.GetManagedObjects();
        }

        public static Adapter1 find_adapter()
        {
            return find_adapter_in_objects(get_managed_objects());
        }

        public static Adapter1 find_adapter_in_objects(IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> managedObjects)
        {
            var bus = Bus.System;
            ObjectPath adapterPath = null;
            foreach (var obj in managedObjects.Keys)
            {
                if (managedObjects[obj].ContainsKey(typeof(Adapter1).DBusInterfaceName()))
                {
                    adapterPath = obj;
                    break;
                }
            }

            var adapter = bus.GetObject<Adapter1>(ServiceName, adapterPath);

            return adapter;
        }

        public static Device1 find_device(string device_address)
        {
            return find_device_in_objects(get_managed_objects(), device_address);
        }

        public static Device1 find_device_in_objects(IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> managedObjects, string device_adress)
        {
            var bus = Bus.System;
            ObjectPath devicePath = null;
            foreach (var obj in managedObjects.Keys)
            {
                if (managedObjects[obj].ContainsKey(typeof(Device1).DBusInterfaceName()))
                {
                    devicePath = obj;
                    break;
                }
            }

            var device = bus.GetObject<Device1>(ServiceName, devicePath);

            return device;
        }
    }
}
