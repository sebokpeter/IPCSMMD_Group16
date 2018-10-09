using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public class OrderLine
    {
        public int BeerID { get; set; }
        public Beer Beer { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int Quanity { get; set; }
    }
}
