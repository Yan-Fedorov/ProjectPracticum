using Project.Domain.Services.CourseField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.CourseField
{
    public class CourseService: IRepository<Course, CourseInfo>
    {
        private readonly ModelContext _modelContext;
        public CourseService(ModelContext context)
        {
            _modelContext = context;
        }
        private Course Create(CourseInfo item)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                EndTime = item.EndTime,
                Tasks = item.Tasks,
                StartTime = item.StartTime,
                PeopleLimit = item.PeopleLimit,
                Vacancy = item.Vacancy
            };
            return course;
        }

        public Course Add(CourseInfo newTask)
        {
            Course course = Create(newTask);
            _modelContext.Courses.Add(course);
            _modelContext.SaveChanges();
            return course;
        }
        public Course AddToCompany(CourseInfo newCourse, Guid companyId)
        {
            Course course = Create(newCourse);
            _modelContext.Courses.Add(course);
            var company = _modelContext.Companies.FirstOrDefault(x => x.Id == companyId);
            company.Courses.Add(course);
            _modelContext.SaveChanges();
            return course;
        }

        public void Delete(Guid id)
        {
            Course course = _modelContext.Courses.FirstOrDefault(x => x.Id == id);
            _modelContext.Courses.Remove(course);
            _modelContext.SaveChanges();
        }

        public IEnumerable<Course> GetItemsList()
        {
            return _modelContext.Courses.ToList();
        }

        public Course GetElementById(Guid id)
        {
            return _modelContext.Courses
                .Where(x => x.Id == id).Select(x => new Course
                {
                    Id = x.Id,
                    PeopleLimit = x.PeopleLimit,
                    Name = x.Name,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Tasks = _modelContext.Tasks.Where(t => t.Course.Id == x.Id).ToList()
                })
                .FirstOrDefault();
        }

    public void Update(Guid id, CourseInfo item)
        {
            var originalCourse = _modelContext.Courses.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalCourse).CurrentValues.SetValues(item);
            _modelContext.SaveChanges();
        }

        //public IEnumerable<Course> GetUserCourses(Guid userId)
        //{
        //    return _modelContext.Users
        //        .First(x => x.Id == userId)
        //        .Courses;
        //} 
    }
}
