using Diwash.SchoolSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diwash.SchoolSystem.Data
{
    public class SchoolSystemDbContext: DbContext
    {
        public SchoolSystemDbContext(DbContextOptions<SchoolSystemDbContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
