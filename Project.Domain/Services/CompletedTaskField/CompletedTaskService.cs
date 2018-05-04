using Microsoft.EntityFrameworkCore;
using Project.Domain.Services.CompletedTaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.CompletedTaskField
{
    public class CompletedTaskService:IRepository<CompletedTask, CompletedTaskInfo>
    {
        private readonly ModelContext _modelContext;
        public CompletedTaskService(ModelContext context)
        {
            _modelContext = context;
        }
        private CompletedTask Create(CompletedTaskInfo data)
        {
            var completedTask = new CompletedTask
            {
                Id = new Guid(),
                ReceivedPoints = data.ReceivedPoints,
                Solution = data.Solution,
                Task = data.Task

            };
            return completedTask;
        }

        public CompletedTask Add(CompletedTaskInfo newCompletedTask)
        {
            CompletedTask completedTask = Create(newCompletedTask);
            _modelContext.CompletedTasks.Add(completedTask);
            _modelContext.SaveChanges();
            return completedTask;
        }

        public void Delete(Guid id)
        {
            CompletedTask completedTask = _modelContext.CompletedTasks.FirstOrDefault(x => x.Id == id);
            _modelContext.CompletedTasks.Remove(completedTask);
            _modelContext.SaveChanges();
        }

        public IEnumerable<CompletedTask> GetItemsList()
        {
            return _modelContext.CompletedTasks.ToList();
        }

        public CompletedTask GetElementById(Guid id)
        {
            return _modelContext.CompletedTasks
                .Where(x => x.Id == id)
                //.Include(x => x.Notifications)
                .FirstOrDefault();
        }

        public void Update(Guid id, CompletedTaskInfo item)
        {
            var originalCompletedTask = _modelContext.CompletedTasks.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalCompletedTask).CurrentValues.SetValues(item);

            _modelContext.SaveChanges();
        }
    }
}
