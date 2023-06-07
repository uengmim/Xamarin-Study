using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMAP.Models.Common
{
    public class BleModel
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
        public IDevice Device { get; set; }
    }
}