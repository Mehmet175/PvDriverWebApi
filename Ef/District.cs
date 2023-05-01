using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class District
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
