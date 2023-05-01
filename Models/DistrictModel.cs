using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class DistrictModel
    {
        public int ID { get; set; }

        public int? CityID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }
    }
}
