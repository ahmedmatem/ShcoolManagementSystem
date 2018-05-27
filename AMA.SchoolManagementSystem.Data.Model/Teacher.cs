namespace AMA.SchoolManagementSystem.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AMA.SchoolManagementSystem.Data.Model.Abstracts;

    public class Teacher : Person
    {
        public string UserId { get; set; }

        public int SchoolId { get; set; }

        public int? AddressId { get; set; }

        public int? GroupId { get; set; }

        // navigation properties

        public virtual User User { get; set; }

        public virtual School School { get; set; }

        public virtual Group Group { get; set; }

        public virtual Address Address { get; set; }
    }
}
