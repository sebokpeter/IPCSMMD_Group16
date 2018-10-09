using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.DomainService
{
    public interface IBeerRepository
    {
        //Returns a list of all the Beer from the database
        IEnumerable<Beer> GetAll();
        //Returns a filtered list of Beer
        IEnumerable<Beer> GetFiltered(BeerFilter filter = null);
        //Returns a Beer by the provided ID
        Beer GetByID(int id);

        //Saves a new Beer to the database
        Beer Save(Beer beer);

        //Updates an existing Beer in the database
        Beer Update(int id, Beer beer);

        //Removes a Beer from the database by the provided ID
        Beer Remove(int id);
    }
}
