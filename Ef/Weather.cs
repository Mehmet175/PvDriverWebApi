using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class Weather
    {
        public int Id { get; set; }
        public int? CityCode { get; set; }
        public string Image { get; set; }
        public DateTime Day { get; set; }
        public string DayName { get; set; }
        public string Humidity { get; set; }
        public string Degree { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Night { get; set; }
    }
}
