using Diwash.SchoolSystem.Data;
using Diwash.SchoolSystem.Data.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Diwash.SchoolSystem.Services
{
    public class ClassService : IClassService
    {
        private static readonly string[] validClasses = new[]
        {
            "Class 1", "Class 2", "Class 3", "Class 4", "Class 5", "Class 6", "Class 7", "Class 8", "Class 9", "Class 10"
        };
        private readonly SchoolSystemDbContext _dbContext;

        public ClassService(SchoolSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //create class
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

        //get all classes
        public async Task<List<Class>> GetAllClasses()
        {
            return await _dbContext.Classes.ToListAsync();
        }

        //update class
        public async Task<bool> UpdateClass(int id, Class updatedClass)
        {
            if (id != updatedClass.Id) return false;
            _dbContext.Update(updatedClass);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        //delete class
        public async Task<bool> DeleteClass(int id)
        {
            var getClass = await _dbContext.Classes.SingleOrDefaultAsync(x => x.Id == id);
            if (getClass == null) return false;
            _dbContext.Remove(getClass);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
