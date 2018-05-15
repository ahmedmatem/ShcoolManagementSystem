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
        public Guid AddressId { get; set; }

        public Guid ERegisterId { get; set; }

        public virtual string Address { get; set; }
        
        public virtual ERegister ERegister { get; set; }
    }
}
