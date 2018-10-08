using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        public IEnumerable<Beer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beer> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beer> GetFiltered()
        {
            throw new NotImplementedException();
        }

        public Beer Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Beer Save(Beer beer)
        {
            throw new NotImplementedException();
        }

        public Beer Update(int id, Beer beer)
        {
            throw new NotImplementedException();
        }
    }
}
