using Diwash.SchoolSystem.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Data
{
    public static class Seeding
    {
        public static void Seed(this IServiceCollection services)
        {
            IServiceScope serviceScope = services.BuildServiceProvider().CreateScope();
            SchoolSystemDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<SchoolSystemDbContext>();
            List<Class> classes = new List<Class>
            {
                new Class
                {
                    Name = "Class 1",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Name="Diwas Sherestha",
                            DateOfBirth=DateTime.Now,
                        },
                         new Student
                        {
                            Name="Shreya Sherestha",
                            DateOfBirth=DateTime.Now,
                        }
                    }
                },
                new Class
                {
                    Name = "Class 2",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Name="Shree Sherestha",
                            DateOfBirth=DateTime.Now,
                        },
                         new Student
                        {
                            Name="Sujana Sherestha",
                            DateOfBirth=DateTime.Now,
                        }
                    }
                }
            };

            if(!dbContext.Classes.Any())
            {
                dbContext.Classes.AddRange(classes);
                dbContext.SaveChanges();
            }           
        }
    }
}
