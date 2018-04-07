using Project.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CompanyField
{
    public class CompanyService : IRepository<CompanyInfo>
    {
        private readonly ModelContext _context;
        public CompanyService(ModelContext context)
        {
            _context = context;
        }
        public void Create(CompanyInfo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyInfo> GetBookList()
        {
            throw new NotImplementedException();
        }

        public List<CompanyInfo> GetElements()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
