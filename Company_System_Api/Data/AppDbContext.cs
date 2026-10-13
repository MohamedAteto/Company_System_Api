using Company_System_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_System_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        // Add your DbSet properties here for your entities
        // Example:
        // public DbSet<Employee> Employees { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }  
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
               .HasMany(d => d.Projects)
               .WithOne(e => e.department)
               .HasForeignKey(e => e.DepartmentId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
               .HasMany(d => d.ProjectsEmployees)
               .WithOne(e => e.Employee)
               .HasForeignKey(e => e.EmployeeId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
             .HasMany(d => d.ProjectsEmployees)
             .WithOne(e => e.Project)
             .HasForeignKey(e => e.ProjectId)
             .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Department>()
                .HasData(
                    new Department { Id = 1, Name = "Human Resources", Location = "New York"  },
                    new Department { Id = 2, Name = "Finance", Location = "London" },
                    new Department { Id = 3, Name = "IT", Location = "San Francisco" }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                
                 new Employee { Id = 1 , FullName = "Mohamed Hassan" ,Email ="mohamedhassan@gmail.com" , Salary = 12323, HireDate = new DateTime(2024,9,13) , DepartmentId = 1},
                 new Employee { Id = 2, FullName = "Malak mostafa", Email = "malakmostafa@gmail.com", Salary = 100000, HireDate = new DateTime(2023, 9, 13), DepartmentId = 2 }
                );

            modelBuilder.Entity<Project>()
                .HasData(

                    new Project { Id = 1, Name = "Project A", Description = "Description for Project A", StartDate = new DateTime(2024, 9, 13), Budget = 50000, DepartmentId = 1 },
                    new Project { Id = 2, Name = "Project B", Description = "Description for Project B", StartDate = new DateTime(2024, 9, 13), Budget = 75000, DepartmentId = 2 }
                );

            modelBuilder.Entity<EmployeeProject>()
                .HasData(
                    new EmployeeProject { id = 1, AssignedRole = "Developer", AssignedDate = new DateTime(2024, 9, 13), EmployeeId = 1, ProjectId = 1  },
                    new EmployeeProject { id = 2, AssignedRole = "Tester", AssignedDate = new DateTime(2024, 9, 13), EmployeeId = 2, ProjectId = 2 }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User { UserId = 1, Username = "admin", Password = "admin123" , Email = "admin1@gmail.com" , Role = "Admin"},
                    new User { UserId = 2, Username = "member", Password = "member123", Email = "member1@gmail.com", Role = "Member" }
                );
        }


    }
}
