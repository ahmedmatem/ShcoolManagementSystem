namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ERegister : SchoolObject
    {
        public Guid SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
