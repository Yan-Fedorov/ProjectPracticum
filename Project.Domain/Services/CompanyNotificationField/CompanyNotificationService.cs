using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Domain.Services.CompanyNotificationField
{
    public class CompanyNotificationService: IRepository<CompanyNotification, CompanyNotificationInfo>
    {
        private readonly ModelContext _modelContext;
        public CompanyNotificationService(ModelContext context)
        {
            _modelContext = context;
        }
        public CompanyNotification Create(CompanyNotificationInfo data)
        {
            var companyNotification = new CompanyNotification
            {
                Id = new Guid(),
                Companies = data.Companies,
                DateTime = data.DateTime,
                Info = data.Info 
            };
            return companyNotification;
        }

        public CompanyNotification Add(CompanyNotificationInfo newCompanyNotificationInfo)
        {
            CompanyNotification companyNotification = Create(newCompanyNotificationInfo);
            _modelContext.CompanyNotifications.Add(companyNotification);
            _modelContext.SaveChanges();
            return companyNotification;
        }

        public void Delete(Guid id)
        {
            CompanyNotification companyNotification = _modelContext.CompanyNotifications.FirstOrDefault(x => x.Id == id);
            _modelContext.CompanyNotifications.Remove(companyNotification);
            _modelContext.SaveChanges();
        }

        public IEnumerable<CompanyNotification> GetItemsList()
        {
            return _modelContext.CompanyNotifications.ToList();
        }

        public CompanyNotification GetElementById(Guid id)
        {
            return _modelContext.CompanyNotifications
                .Where(x => x.Id == id)
                .Include(x => x.Companies)
                .FirstOrDefault();
        }

        public void Update(Guid id, CompanyNotificationInfo item)
        {
            var originalCompanyNotification = _modelContext.CompanyNotifications.
                FirstOrDefault(o => o.Id == id);
            var companyNotification = Create(item);
            _modelContext.Entry(originalCompanyNotification).CurrentValues.SetValues(item);

            _modelContext.SaveChanges();
        }
    }
}
