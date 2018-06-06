using Microsoft.EntityFrameworkCore;
using Project.Domain.Services.TaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.UserAndCoursesField
{
    public class UserAndCoursesService
    {
        private readonly ModelContext _modelContext;
        public UserAndCoursesService(ModelContext context)
        {
            _modelContext = context;
        }
        public UserAndCourses AddCourseToUser(Guid courseId, Guid userId)
        {
            var userCourse = new UserAndCourses
            {
                Id = new Guid(),
                User = _modelContext.Users.FirstOrDefault(x => x.Id == userId),
                Course = _modelContext.Courses.FirstOrDefault(x => x.Id == courseId)
            };
            _modelContext.UserAndCourses.Add(userCourse);
            _modelContext.SaveChanges();
            return userCourse;
        }
        public IEnumerable<UserAndCoursesInfo> GetUserCourses(Guid userId)
        {
            var ls = _modelContext.UserAndCourses
                .Include(x => x.Course)
                .Include(x => x.Course.Tasks)
                .Where(x => x.User.Id == userId)
                .ToList();

            return ls
                .Select(x => new UserAndCoursesInfo
                {
                    CoursId = x.Course.Id,
                    Name = x.Course.Name,
                    StartTime = x.Course?.StartTime,
                    EndTime = x.Course?.EndTime,
                    Tasks = x.Course?.Tasks?.Select(t => new TaskInfo
                    {
                        Id = t.Id,
                        Answers = t.Answers,
                        Info = t.Info,
                        Points = t.Points,
                        Name = t.Name
                    }).ToList()
                })
                .ToList();
        }


        //public Task Add(TaskInfo newTask)
        //{
        //    Task task = Create(newTask);
        //    _modelContext.Tasks.Add(task);
        //    _modelContext.SaveChanges();
        //    return task;
        //}

        //public void Delete(Guid id)
        //{
        //    Task task = _modelContext.Tasks.FirstOrDefault(x => x.Id == id);
        //    _modelContext.Tasks.Remove(task);
        //    _modelContext.SaveChanges();
        //}

        //public IEnumerable<Task> GetUserCourses()
        //{
        //    return _modelContext.Tasks.ToList();
        //}

        //public Task GetElementById(Guid id)
        //{
        //    return _modelContext.Tasks
        //        .Where(x => x.Id == id)
        //        .FirstOrDefault();
        //}

        //public void Update(Guid id, TaskInfo item)
        //{
        //    var originalTask = _modelContext.Tasks.
        //        FirstOrDefault(o => o.Id == id);
        //    _modelContext.Entry(originalTask).CurrentValues.SetValues(item);
        //    _modelContext.SaveChanges();
        //}
    }
}
