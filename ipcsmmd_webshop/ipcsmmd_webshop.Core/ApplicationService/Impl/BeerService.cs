using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;

namespace ipcsmmd_webshop.Core.ApplicationService.Impl
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepo;

        public BeerService(IBeerRepository repository)
        {
            _beerRepo = repository;
        }

        public Beer AddBeer(Beer beer)
        {
            if (beer == null)
            {
                throw new InvalidDataException("Input is null!");
            }
            if (beer.ID != 0)
            {
                throw new InvalidDataException("Cannot add a Beer with existing id!");
            }
            if (string.IsNullOrEmpty(beer.Name))
            {
                throw new InvalidDataException("Cannot add a Beer without name!");
            }
            if (string.IsNullOrEmpty(beer.Brand))
            {
                throw new InvalidDataException("Cannot add a Beer without brand!");
            }

            return _beerRepo.Save(beer);
        }

        public Beer GetBeerByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Beer> GetBeers()
        {
            throw new NotImplementedException();
        }

        public List<Beer> GetBeersByPrice(bool isAscending)
        {
            throw new NotImplementedException();
        }

        public List<Beer> GetBeersByType(BeerType type)
        {
            throw new NotImplementedException();
        }

        public List<Beer> GetFilteredBeers(BeerFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beer> ReadBeers()
        {
            throw new NotImplementedException();
        }

        public Beer RemoveBeer(int id)
        {
            throw new NotImplementedException();
        }

        public Beer UpdateBeer(Beer beer)
        {
            throw new NotImplementedException();
        }
    }
}
