namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post : DataModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set;  }
    }
}
