namespace AMA.SchoolManagementSystem.Data.Model
{
    using AMA.SchoolManagementSystem.Data.Model.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Principal : Teacher
    {
        public PositionType Type { get; set; }
    }
}
