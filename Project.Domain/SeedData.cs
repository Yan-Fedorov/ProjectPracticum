using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
//using Project.Domain.Model;
using System.Collections.Generic;

namespace Project.Domain
{
    public static class SeedData
    {
        public static void Initialize(ModelContext _modelContext)
        {
            _modelContext.Database.EnsureCreated();

            var task1 = new Task()
            {
                Name = "task1",
                Id = new Guid(),
                Points = 3,
                Answers = "3",
                Info = "3"
            };
            var task2 = new Task()
            {
                Name = "task2",
                Id = new Guid(),
                Points = 1,
                Answers = "1",
                Info = "1"
            };
            var task3 = new Task()
            {
                Name = "task3",
                Id = new Guid(),
                Points = 2,
                Answers = "2",
                Info = "2"
            };
            var task4 = new Task()
            {
                Name = "task4",
                Id = new Guid(),
                Points = 4,
                Answers = "4",
                Info = "4"
            };
            if (!_modelContext.Tasks.Any())
            {
                _modelContext.Tasks.AddRange(task1, task2, task3, task4);
            }

            var course1 = new Course()
            {
                Id = new Guid(),
                Name = "C++ Junior",
                PeopleLimit = 5,
                Tasks = new List<Task>() { task2, task3 }
            };
            var course2 = new Course()
            {
                Id = new Guid(),
                Name = "C++ Middle",
                PeopleLimit = 10,
                Tasks = new List<Task>() { task1, task4 }
            };
            task1.Course = course2;
            task2.Course = course1;
            task3.Course = course1;
            task4.Course = course2;
            if (!_modelContext.Courses.Any())
            {
                _modelContext.Courses.AddRange(course1, course2);
            }


            User user1 = new User()
            {
                Id = new Guid(),
                Name = "Иванов Иван Иванович",
                Password = "12345",
                Email = "ivanov@gmail.com",
                Info = "Работяга с завода",
            };

            User user2 = new User()
            {
                Id = new Guid(),
                Name = "Павлов Павел Павлович",
                Password = "123456",
                Email = "pavlov@gmail.com"
            };

            User user3 = new User()
            {
                Id = new Guid(),
                Name = "Степанов Степан Степанович",
                Password = "123457",
                Email = "stepanov@gmail.com"
            };

            User user4 = new User()
            {
                Id = new Guid(),
                Name = "Петров Пётр Петрович",
                Password = "123458",
                Email = "petrov@gmail.com",
            };

            if (!_modelContext.Users.Any())
            {
                _modelContext.Users.AddRange(user1, user2, user3, user4);
            }

            UserAndCourses userCourses1 = new UserAndCourses()
            {
                Course = course1,
                Id = new Guid(),
                User = user1
            };
            if (!_modelContext.UserAndCourses.Any())
            {
                _modelContext.UserAndCourses.AddRange(userCourses1);
            }

            if (!_modelContext.Companies.Any())
            {
                _modelContext.Companies.AddRange(
                    new Company
                    {
                        Id = new Guid(),
                        Name = "Global Logic",
                        Contacts = "gl@gl.com",
                        Info = "InfoGL"
                    }, new Company
                    {
                        Id = new Guid(),
                        Name = "Nix Solution",
                        Contacts = "nx@nx.com",
                        Info = "InfoNX"
                    }, new Company
                    {
                        Id = new Guid(),
                        Name = "Epam",
                        Contacts = "ep@ep.com",
                        Info = "InfoEp"
                    }, new Company
                    {
                        Id = new Guid(),
                        Name = "Nure",
                        Contacts = "nure@nure.com",
                        Info = "InfoNure"
                    }, new Company
                    {
                        Id = new Guid(),
                        Name = "1",
                        Contacts = "nure@nure.com",
                        Info = "InfoNure",
                        Password = "1",
                        Courses = new List<Course>() { course1 }
                    });
            }
            _modelContext.SaveChanges();
        }
    }
}

