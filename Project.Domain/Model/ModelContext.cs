using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace Project.Domain
{
    public interface IModelContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Company> Companys { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<CompletedTask> CompletedTasks { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
        DbSet<CompanyNotification> CompanyNotifications { get; set; }
        DbSet<Company_Notification> Company_Notifications { get; set; }
        DbSet<UserAndNotification> CompanyAndNotifications { get; set; }
        DbSet<UserAndCourses> UserAndCourses { get; set; }

    }
    public class ModelContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<CompletedTask> CompletedTasks { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<CompanyNotification> CompanyNotifications { get; set; }
        public DbSet<Company_Notification> Company_Notifications { get; set; }
        public DbSet<UserAndNotification> CompanyAndNotifications { get; set; }
        public DbSet<UserAndCourses> UserAndCourses { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
