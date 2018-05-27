namespace AMA.SchoolManagementSystem.Data.Model.Abstracts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Person : SchoolObject
    {
        [NotMapped]
        public string FirstName => Name.Split(' ')[0];

        [NotMapped]
        public string FatherName => Name.Split(' ')[1];

        [NotMapped]
        public string LastName => Name.Split(' ')[2];
    }
}
