using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private WebShopContext _ctx;

        public BeerRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Beer> GetAll()
        {
            return _ctx.Beers; //.Include(b => b.OrderLines);
        }

        public Beer GetByID(int id)
        {
            return _ctx.Beers./*Include(b => b.OrderLines).*/FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Beer> GetFiltered(BeerFilter beerFilter)
        {
            if (beerFilter == null)
            {
                return _ctx.Beers;
            }

            IEnumerable<Beer> beers = _ctx.Beers
                .Skip((beerFilter.CurrentPage - 1) * beerFilter.ItemsPerPage)
                .Take(beerFilter.ItemsPerPage);

            if (beerFilter.IsAscending)
            {
                switch(beerFilter.SearchField)
                {
                    case BeerFilter.Field.Id:
                        beers = beers.OrderBy(x => x.ID);
                        break;
                    case BeerFilter.Field.Name:
                        beers = beers.OrderBy(x => x.Name);
                        break;
                    case BeerFilter.Field.Brand:
                        beers = beers.OrderBy(x => x.Brand);
                        break;
                    case BeerFilter.Field.Type:
                        beers = beers.OrderBy(x => x.Type);
                        break;
                }    
            }
            else
            {
                switch (beerFilter.SearchField)
                {
                    case BeerFilter.Field.Id:
                        beers = beers.OrderByDescending(x => x.ID);
                        break;
                    case BeerFilter.Field.Name:
                        beers = beers.OrderByDescending(x => x.Name);
                        break;
                    case BeerFilter.Field.Type:
                        beers = beers.OrderByDescending(x => x.Type);
                        break;
                    case BeerFilter.Field.Brand:
                        beers = beers.OrderByDescending(x => x.Brand);
                        break;
                    default:
                        break;
                }
            }
            return beers;
        }

        public Beer Remove(int id)
        {
            Beer beerToRemove = GetByID(id);
            _ctx.Beers.Remove(beerToRemove);
            _ctx.SaveChanges();
            return beerToRemove;
        }

        public Beer Save(Beer beer)
        {
            Beer beerSave = _ctx.Beers.Add(beer).Entity;
            
            _ctx.SaveChanges();
            return beerSave;
        }

        public Beer Update(Beer beer)
        {
            _ctx.Attach(beer).State = EntityState.Modified;
            _ctx.SaveChanges();
            return beer;
        }
    }
}
