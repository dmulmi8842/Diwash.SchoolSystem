using System;

namespace Diwash.SchoolSystem.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Grade Grade { get; set; }
    }
}
