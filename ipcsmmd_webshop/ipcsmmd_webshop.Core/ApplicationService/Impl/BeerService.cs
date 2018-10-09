using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (beer.Price == 0.0f)
            {
                throw new InvalidDataException("Cannot add a Beer without price!");
            }

            return _beerRepo.Save(beer);
        }

        public Beer GetBeerByID(int id)
        {
            if (id < 1)
            {
                throw new InvalidDataException("ID must be greater than 0!");
            }

            return _beerRepo.GetByID(id);
        }

        public List<Beer> GetBeers()
        {
            return _beerRepo.GetAll().ToList();
        }

        public List<Beer> GetBeersByPrice(bool isAscending)
        {
            if (isAscending)
            {
                return _beerRepo.GetAll().OrderBy(x => x.Price).ToList();
            }
            else
            {
                return _beerRepo.GetAll().OrderByDescending(x => x.Price).ToList();
            }

        }


        public List<Beer> GetBeersByType(BeerType type)
        {
            return _beerRepo.GetAll().Where(x => x.Type == type).ToList();
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
