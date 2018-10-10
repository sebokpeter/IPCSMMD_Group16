using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;

namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface IBeerService
    {
        /// <summary>
        /// Fetch the list of the beers without any filtering.
        /// </summary>
        /// <returns>The list of beers</returns>
        List<Beer> GetBeers();

        /// <summary>
        /// Fetch the list of the beers without any filtering.
        /// </summary>
        /// <returns>The list of beers</returns>
        IEnumerable<Beer> ReadBeers();

        /// <summary>
        /// Add a beer to the database.
        /// </summary>
        /// <param name="beer">The beer that will be added</param>
        /// <returns>The beers that was added.</returns>
        Beer AddBeer(Beer beer);

        /// <summary>
        /// Remove a beer from the database, based on ID.
        /// </summary>
        /// <param name="id">The id of the beer that will be removed.</param>
        /// <returns>The removed beer.</returns>
        Beer RemoveBeer(int id);

        /// <summary>
        /// Fetch a beer based on id.
        /// </summary>
        /// <param name="id">The id of the beer that will be returned.</param>
        /// <returns>The beer with the given id. If not found, null will be returned.</returns>
        Beer GetBeerByID(int id);

        /// <summary>
        /// Update a beer.
        /// </summary>
        /// <param name="beer">The beer that will be updated.</param>
        /// <returns>The updated beer.</returns>
        Beer UpdateBeer(Beer beer);

        /// <summary>
        /// Fetch a filtered list if beers.
        /// </summary>
        /// <param name="filter">The filter that will be used to determine which beers to return.</param>
        /// <returns>A filtered list of beers.</returns>
        List<Beer> GetFilteredBeers(BeerFilter filter);

        /// <summary>
        /// Fetch a list of beers with a specific type.
        /// </summary>
        /// <param name="type">The type of beers that will be returned.</param>
        /// <returns></returns>
        List<Beer> GetBeersByType(BeerType type);

        /// <summary>
        /// fetch a list of beers, ordered by their price.
        /// </summary>
        /// <param name="isAscending">Determines wheter the list will be ordered ascending or descending based on price.</param>
        /// <returns>A list of beers, ordered by their price.</returns>
        List<Beer> GetBeersByPrice(bool isAscending);
        
    }
}
