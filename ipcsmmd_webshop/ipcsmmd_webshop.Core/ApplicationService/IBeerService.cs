using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;

namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface IBeerService
    {
        List<Beer> GetBeers();

        IEnumerable<Beer> ReadBeers();

        Beer AddBeer(Beer beer);

        Beer RemoveBeer(int id);

        Beer GetBeerByID(int id);

        Beer UpdateBeer(Beer beer);

        // TODO: Add filtering methonds
        //List<Beer> GetFilteredBeers(BeerFilter filter);

        List<Beer> GetBeersByType(BeerType type);

        List<Beer> GetBeersByPrice(bool isAscending);
        
    }
}
