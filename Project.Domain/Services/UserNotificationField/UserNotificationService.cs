using Microsoft.EntityFrameworkCore;
using Project.Domain.Services.CompletedTaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.UserNotificationField
{
    public class UserNotificationService: IRepository<UserNotification, UserNotificationInfo>
    {
        private readonly ModelContext _modelContext;
        public UserNotificationService(ModelContext context)
        {
            _modelContext = context;
        }
        private UserNotification Create(UserNotificationInfo data)
        {
            var userNotification = new UserNotification
            {
                Id = new Guid(),
                DateTime = data.DateTime,
                Info = data.Info,
                Users = data.Users
            };
            return userNotification;
        }

        public UserNotification Add(UserNotificationInfo newUserNotification)
        {
            UserNotification userNotification = Create(newUserNotification);
            _modelContext.UserNotifications.Add(userNotification);
            _modelContext.SaveChanges();
            return userNotification;
        }

        public void Delete(Guid id)
        {
            UserNotification userNotification = _modelContext.UserNotifications.FirstOrDefault(x => x.Id == id);
            _modelContext.UserNotifications.Remove(userNotification);
            _modelContext.SaveChanges();
        }

        public IEnumerable<UserNotification> GetItemsList()
        {
            return _modelContext.UserNotifications.ToList();
        }

        public UserNotification GetElementById(Guid id)
        {
            return _modelContext.UserNotifications
                .Where(x => x.Id == id)
                .Include(x => x.Users)
                .FirstOrDefault();
        }

        public void Update(Guid id, UserNotificationInfo item)
        {
            var originalUserNotification = _modelContext.UserNotifications.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalUserNotification).CurrentValues.SetValues(item);

            _modelContext.SaveChanges();
        }
    }
}
