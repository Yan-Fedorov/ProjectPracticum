using Microsoft.EntityFrameworkCore;
//using Project.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.CompanyField
{
    public class CompanyService : IRepository<Company, CompanyInfo>
    {
        private readonly ModelContext _modelContext;
        public CompanyService(ModelContext context)
        {
            _modelContext = context;
        }
        private Company Create(CompanyInfo data)
        {
            var company = new Company
            {
                Id = new Guid(),
                Name = data.Name,
                Courses = data.Courses,
                Contacts = data.Contacts,
                Info = data.Info,
                Password = data.Password,
                Notifications = data.Notifications
            };
            return company;
        }

        public Company Add(CompanyInfo newCompany)
        {
            Company company = Create(newCompany);
            _modelContext.Companies.Add(company);
            _modelContext.SaveChanges();
            return company;
        }

        public void Delete(Guid id)
        {
            Company company = _modelContext.Companies.FirstOrDefault(x => x.Id == id);
            _modelContext.Companies.Remove(company);
            _modelContext.SaveChanges();
        }

        public IEnumerable<Company> GetItemsList()
        {
            return _modelContext.Companies.ToList();
        }

        public Company GetElementById(Guid id)
        {
            return _modelContext.Companies
                .Where(x => x.Id == id)
                .Include(x => x.Notifications)
                .FirstOrDefault();
        }

        public void Update(Guid id, CompanyInfo item)
        {
            var originalCompany = _modelContext.Companies.
                FirstOrDefault(o => o.Id == id);
            _modelContext.Entry(originalCompany).CurrentValues.SetValues(item);

            _modelContext.SaveChanges();
        }
    }
}
