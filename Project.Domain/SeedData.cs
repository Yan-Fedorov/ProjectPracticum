using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Project.Domain.Model;

namespace Project.Domain
{
    public static class SeedData
    {
        public static void Initialize(ModelContext _modelContext)
        {
            _modelContext.Database.EnsureCreated();

            // Look for any movies.
            if (!_modelContext.Users.Any())
            {
                _modelContext.Users.AddRange(
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
                        });
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
},
new Company
{
    Id = new Guid(),
    Name = "Nix Solution",
    Contacts = "nx@nx.com",
    Info = "InfoNX"
},
new Company
{
    Id = new Guid(),
    Name = "Epam",
    Contacts = "ep@ep.com",
    Info = "InfoEp"
},
new Company
{
    Id = new Guid(),
    Name = "Nure",
    Contacts = "nure@nure.com",
    Info = "InfoNure"
}
);
            }

            _modelContext.SaveChanges();
        }
    }
}

