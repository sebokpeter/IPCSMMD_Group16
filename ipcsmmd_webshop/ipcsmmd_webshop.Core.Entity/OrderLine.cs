using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public class OrderLine
    {
        public Beer Beer { get; set; }
        public Order Order { get; set; }
        public int Quanity { get; set; }
    }
}
