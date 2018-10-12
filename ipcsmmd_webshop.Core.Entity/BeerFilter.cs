using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public class BeerFilter
    {
        public enum Field
        {
            Id,
            Name,
            Type,
            Brand
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public bool IsAscending { get; set; }
        public Field SearchField { get; set; }
        public string SearchString { get; set; }
    }
}
