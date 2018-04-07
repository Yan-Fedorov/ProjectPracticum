using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Project.Domain.Model;

namespace Project.Domain
{
    public static class SeedUserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ModelContext(
                serviceProvider.GetRequiredService<DbContextOptions<ModelContext>>()))//ПОЛУчать модель из зависимости
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                     new User
                     {
                         Id = new Guid(),
                         Name = "Иванов Иван Иванович",
                         Password = "12345",
                         Email = "ivanov@gmail.com"                         
                     },

                      new User
                      {
                          Id = new Guid(),
                          Name = "Павлов Павел Павлович",
                          Password = "123456",
                          Email = "pavlov@gmail.com"
                      },

                     new User
                     {
                         Id = new Guid(),
                         Name = "Степанов Степан Степанович",
                         Password = "123457",
                         Email = "stepanov@gmail.com"
                     },

                    new User
                    {
                        Id = new Guid(),
                        Name = "Петров Пётр Петрович",
                        Password = "123458",
                        Email = "petrov@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
