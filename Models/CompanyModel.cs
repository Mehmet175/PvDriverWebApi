using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? TopCompany { get; set; }

        public bool? Status { get; set; }
    }
}
