namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student : Person
    {
        public int? AddressId { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Address Address { get; set; }
    }
}
