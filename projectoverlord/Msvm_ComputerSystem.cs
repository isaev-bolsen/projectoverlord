﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Linq;
using System.Management;
using WMIWG;

namespace projectoverlord.HyperVAdapter
{
    public class Msvm_ComputerSystem
    {
        private readonly ManagementObject _instance;

        public string Name => (string)_instance["name"];

        internal Msvm_ComputerSystem(string Path) : this(new ManagementObject(Path)) { }

        internal Msvm_ComputerSystem(ManagementObject instance)
        {
            new WMIWrapperGenerator().Generate(instance, "projectoverlord.HyperVAdapter");
            _instance = instance;
        }
    }
}