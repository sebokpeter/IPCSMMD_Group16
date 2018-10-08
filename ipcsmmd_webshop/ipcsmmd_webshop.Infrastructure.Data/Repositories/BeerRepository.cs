using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class BeerRepository : IBeerRepository
    {
<<<<<<< HEAD
        public IEnumerable<Beer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beer> GetByID(int id)
        {
            throw new NotImplementedException();
=======
        private WebShopContext _ctx;

        public BeerRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Beer> GetAll()
        {
            return _ctx.Beers;
        }

        public Beer GetByID(int id)
        {
            return _ctx.Beers.FirstOrDefault(b => b.ID == id);
>>>>>>> master
        }

        public IEnumerable<Beer> GetFiltered()
        {
            throw new NotImplementedException();
        }

        public Beer Remove(int id)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            Beer beer = _ctx.Beers.Remove(new Beer { ID = (uint) id }).Entity;
            _ctx.SaveChanges();
            return beer;
>>>>>>> master
        }

        public Beer Save(Beer beer)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            Beer beerSave = _ctx.Beers.Add(beer).Entity;
            _ctx.SaveChanges();
            return beerSave;
>>>>>>> master
        }

        public Beer Update(int id, Beer beer)
        {
            throw new NotImplementedException();
        }
    }
}
