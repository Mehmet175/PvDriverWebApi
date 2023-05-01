﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class PackageTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool? Status { get; set; }
    }
}
