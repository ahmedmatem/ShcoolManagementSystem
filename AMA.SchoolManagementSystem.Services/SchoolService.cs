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

    public class SchoolService : ISchoolService
    {
        private readonly IEfRepository<School> schoolRepository;
        private readonly ISaveContext context;

        public SchoolService(IEfRepository<School> schoolRepository, ISaveContext context)
        {
            this.schoolRepository = schoolRepository;
            this.context = context;
        }

        public void Add(School newSchool)
        {
            schoolRepository.Add(newSchool);
        }
    }
}
