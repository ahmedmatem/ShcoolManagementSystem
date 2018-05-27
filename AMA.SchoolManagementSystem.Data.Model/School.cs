namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School : SchoolObject
    {
        private ICollection<Teacher> teachers;

        public School()
        {
            this.teachers = new HashSet<Teacher>();
        }

        public string AdminId { get; set; }

        public int AddressId { get; set; }

        public int ContactId { get; set; }

        // navigation properties

        public virtual User Admin { get; set; }

        public virtual Address Address { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
