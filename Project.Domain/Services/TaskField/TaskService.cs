using Microsoft.EntityFrameworkCore;
using Project.Domain.Services.TaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.TaskField
{
    public class TaskService: IRepository<Task, TaskInfo>
    {
        private readonly ModelContext _modelContext;
        public TaskService(ModelContext context)
        {
            _modelContext = context;
        }
        private Task Create(TaskInfo item)
        {
            var task = new Task
            {
                Id = Guid.NewGuid(),
                Info = item.Info,
                Points = item.Points,
                Answers = item.Answers
                
            };
            return task;
        }

        public Task Add(TaskInfo newTask)
        {
            Task task = Create(newTask);
            _modelContext.Tasks.Add(task);
            _modelContext.SaveChanges();
            return task;
        }

        public void Delete(Guid id)
        {
            Task task = _modelContext.Tasks.FirstOrDefault(x => x.Id == id);
            _modelContext.Tasks.Remove(task);
            _modelContext.SaveChanges();
        }

        public IEnumerable<Task> GetItemsList()
        {
            return _modelContext.Tasks.ToList();
        }

        public Task GetElementById(Guid id)
        {
            return _modelContext.Tasks
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Update(Guid id, TaskInfo item)
        {
            var originalTask = _modelContext.Tasks.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalTask).CurrentValues.SetValues(item);
            _modelContext.SaveChanges();
        }
    }
}
