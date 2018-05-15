namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Address : DataModel
    {
        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
