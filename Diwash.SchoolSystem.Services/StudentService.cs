using Diwash.SchoolSystem.Data;
using Diwash.SchoolSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Diwash.SchoolSystem.Services
{
    public interface IStudentService
    {
        Task<int> CreateStudent(Student student);
        Task<List<Student>> GetStudents(string nameKeyword);
        Task<Student> GetStudent(int id);
        Task<bool> DeleteStudent(int id);
        Task<bool> UpdateStudent(int id, Student student);
    }
    internal class StudentService : IStudentService
    {
        private readonly SchoolSystemDbContext _dbContext;

        public StudentService(SchoolSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //create student
        public async Task<int> CreateStudent(Student student)
        {
            if (!student.DateOfBirth.HasValue) throw new Exception("Date of Birth should have value.");
            int age = CalculateAge(student.DateOfBirth.Value);
            if (age < 5) throw new Exception("Student must be at least 5 year.");
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return student.Id;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            return DateTime.Now.Year - dateOfBirth.Year;
        }

        //get specific list based on searched name or description / get all list
        public async Task<List<Student>> GetStudents(string nameKeyword)
        {
            //List<Student> students = new List<Student>();
            var students = await _dbContext.Students.Where(x => x.Name.Contains(nameKeyword)).ToListAsync();
            if (!string.IsNullOrEmpty(nameKeyword))
                return students;
            else
                return students = await _dbContext.Students.ToListAsync();
        }

        //get student by student id
        public async Task<Student> GetStudent(int id)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id);
            return student;
        }

        //update student
        public async Task<bool> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
                return false;
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //delete student by id
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return false;
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
