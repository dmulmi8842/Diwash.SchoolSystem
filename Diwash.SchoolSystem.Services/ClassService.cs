using Diwash.SchoolSystem.Data;
using Diwash.SchoolSystem.Data.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Diwash.SchoolSystem.Services
{
    public interface IClassService
    {
        Task<int> CreateClass(Class newClass);
        Task<List<Class>> GetAllClasses();
    }
    internal class ClassService : IClassService
    {
        private string[] validClasses = new string[] { "Class 1", "Class 2", "Class 3", "Class 4", "Class 5", "Class 6", "Class 7", "Class 8", "Class 9", "Class 10" };
        private readonly SchoolSystemDbContext _dbContext;

        public ClassService(SchoolSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CreateClass(Class newClass)
        {
            if (!isValidClass(newClass.Name)) throw new Exception("Class is not available.");
            _dbContext.Classes.Add(newClass);
            await _dbContext.SaveChangesAsync();

            return newClass.Id;
        }
        public bool isValidClass(string name)
        {
            for (int i = 0; i < validClasses.Length; i++)
            {
                if (name.Equals(validClasses[i]))
                    return true;
            }
            return false;
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return await _dbContext.Classes.ToListAsync();
        }

    }
}
