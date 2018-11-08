using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.DomainService
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAll();
        Admin Get(long id);
        void Add(Admin admin);
        void Edit(Admin admin);
        void Remove(long id);
    }
}
