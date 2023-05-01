using System;
using System.Collections.Generic;

#nullable disable

namespace PvDriver.Ef
{
    public partial class DefaultParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parameter { get; set; }
        public int? ModelTypeId { get; set; }
        public bool? Status { get; set; }

        public virtual ModelType ModelType { get; set; }
    }
}
