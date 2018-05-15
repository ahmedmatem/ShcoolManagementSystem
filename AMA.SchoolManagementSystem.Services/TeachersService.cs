namespace AMA.SchoolManagementSystem.Services
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TeachersService : ITeachersService
    {
        private readonly IEfRepository<Teacher> teacherRepository;
        private readonly ISaveContext context;

        public TeachersService(IEfRepository<Teacher> teacherRepository, ISaveContext context)
        {
            this.teacherRepository = teacherRepository;
            this.context = context;
        }

        public void Add(Teacher newTeacher)
        {
            teacherRepository.Add(newTeacher);
        }
    }
}
