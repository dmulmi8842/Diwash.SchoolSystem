using System;
using System.ComponentModel.DataAnnotations;

namespace Diwash.SchoolSystem.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }  
        public int ClassId { get; set; }
        public virtual  Class Class { get; set; }
    }
}
