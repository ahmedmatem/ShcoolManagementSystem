namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Group : SchoolObject
    {
        private ICollection<Student> students;

        public Group()
        {
            this.students = new HashSet<Student>();
        }

        public Guid TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
