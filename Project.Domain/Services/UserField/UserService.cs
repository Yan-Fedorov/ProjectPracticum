using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//using Project.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Project.Domain.Services.UserField
{
    public class UserService : IRepository<User,UserInfo>
    {
        private readonly ModelContext _modelContext;
        public UserService(ModelContext context)
        {
            _modelContext = context;
        }
        private User Create(UserInfo item)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Password = item.Password,
                Email = item.Email,
                CompletedTasks = item.CompletedTasks,
                Info = item.Info,
                Notifications = item.Notifications
            };
            return user;
        }
        public User Add(UserInfo newUser)
        {
            User user = Create(newUser);
            _modelContext.Users.Add(user);
            _modelContext.SaveChanges();
            return user;
        }

        public void Delete(Guid id)
        {
            User user = _modelContext.Users.FirstOrDefault(x => x.Id == id);
            _modelContext.Users.Remove(user);
            _modelContext.SaveChanges();
        }

        public IEnumerable<User> GetItemsList()
        {
            return _modelContext.Users.ToList();
        }

        public User GetElementById(Guid id)
        {
            return _modelContext.Users
                .Where(x => x.Id == id)
                .Include(x => x.Notifications)
                .FirstOrDefault();
        }

        public void Update(Guid id, UserInfo item)
        {
            var originalUser = _modelContext.Users.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalUser).CurrentValues.SetValues(item);

            _modelContext.SaveChanges();
        }
        public User FindByPasswordEmail(string password, string email)
        {
            User person = _modelContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                return person;
        }
    }
}
