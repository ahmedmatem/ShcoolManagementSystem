namespace AMA.SchoolManagementSystem.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AMA.SchoolManagementSystem.Data.Model.Abstracts;

    public class Group : SchoolObject
    {
        private ICollection<Student> students;

        public Group()
        {
            this.students = new HashSet<Student>();
        }

        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
