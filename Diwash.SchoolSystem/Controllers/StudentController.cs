using Diwash.SchoolSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Controllers
{
    public class StudentController
    {
        private readonly SchoolSystemDbContext _schoolSystemDbContext;

        public StudentController(SchoolSystemDbContext schoolSystemDbContext)
        {
            _schoolSystemDbContext = schoolSystemDbContext;
        }
    }
}
