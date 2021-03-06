﻿namespace AMA.SchoolManagementSystem.Services.Contracts
{
    using AMA.SchoolManagementSystem.Data.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITeachersService
    {
        IQueryable<Teacher> All();

        void Add(Teacher newTeacher);
    }
}
