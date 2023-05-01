using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class ModelType
    {
        public ModelType()
        {
            DefaultParameters = new HashSet<DefaultParameter>();
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? Status { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Address6 { get; set; }
        public string Address7 { get; set; }
        public decimal? Dividing1 { get; set; }
        public decimal? Dividing2 { get; set; }
        public decimal? Dividing3 { get; set; }
        public decimal? Dividing4 { get; set; }
        public decimal? Dividing5 { get; set; }
        public decimal? Dividing6 { get; set; }
        public decimal? Dividing7 { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<DefaultParameter> DefaultParameters { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
