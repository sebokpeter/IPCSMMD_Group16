using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly WebShopContext _ctx;

        public AdminRepository(WebShopContext webShopContext)
        {
            this._ctx = webShopContext;
        }

        public void Add(Admin admin)
        {
            _ctx.Admins.Add(admin);
            _ctx.SaveChanges();
        }

        public void Edit(Admin admin)
        {
            _ctx.Entry(admin).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public Admin Get(long id)
        {
            return _ctx.Admins.FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _ctx.Admins;
        }

        public void Remove(long id)
        {
            Admin admin = _ctx.Admins.FirstOrDefault(a => a.ID == id);
            _ctx.Admins.Remove(admin);
            _ctx.SaveChanges();
        }
    }
}
