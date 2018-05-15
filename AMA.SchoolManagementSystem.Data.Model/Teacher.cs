namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Teacher : Person
    {
        public Guid? AddressId { get; set; }

        public Guid? GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Address Address { get; set; }

        [NotMapped]
        public override string Name { get => String.Format("{0} {1} {2}", FirstName, FatherName, LastName); }

        [NotMapped]
        public override string ShortName =>
            FirstName.Substring(0, 1) + FatherName.Substring(0, 1) + LastName.Substring(0, 1);
    }
}
