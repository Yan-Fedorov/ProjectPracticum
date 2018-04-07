using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Project.Domain.Model
{
    public interface IModelContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Company> Companys { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Task> Tasks { get; set; }

    }
    public class ModelContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
    }
}
