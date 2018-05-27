namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Contact : DataModel
    {
        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Email { get; set; }
    }
}
