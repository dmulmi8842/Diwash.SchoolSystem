using Diwash.SchoolSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Services
{
    public interface IClassService
    {
        Task<int> CreateClass(Class newClass);
        Task<List<Class>> GetAllClasses();
        Task<bool> UpdateClass(int id, Class getClass);
        Task<bool> DeleteClass(int id);
    }
}
