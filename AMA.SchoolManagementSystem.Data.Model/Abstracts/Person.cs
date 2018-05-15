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
        public string FirstName { get; set; }

        public string FatherName { get; set; }

        public string LastName { get; set; }

        public abstract string ShortName { get; }
    }
}
