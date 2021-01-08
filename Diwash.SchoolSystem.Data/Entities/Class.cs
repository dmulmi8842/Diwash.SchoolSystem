using System.Collections.Generic;

namespace Diwash.SchoolSystem.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}