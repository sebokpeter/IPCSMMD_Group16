using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public class Admin
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt{ get; set; }
    }
}
