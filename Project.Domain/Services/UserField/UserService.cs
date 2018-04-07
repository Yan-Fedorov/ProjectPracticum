using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project.Domain.Model;

namespace Project.Domain.Services.UserField
{
    public class UserService : IRepository<UserInfo>
    {
        private readonly ModelContext _context;
        public UserService(ModelContext context)
        {
            _context = context;
        }
        public void Create(UserInfo item)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = item.UserName,
                Password = item.UserPassword,
                Email = item.UserEmail            
            };
            _context.Users.Add(user);
            _context.SaveChanges();           
        }
      

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfo> GetBookList()
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetElements()
        {
            return _context.Users.Select(x => new UserInfo
            {
                UserId = x.Id,
                UserName = x.Name,
                UserPassword = x.Password,
                UserEmail = x.Email
            }).ToList();
            
        }
       
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
