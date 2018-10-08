using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public enum BeerType { Dark, Brown, Light}

    public class Beer
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Brand { get; set; }
        public BeerType Type { get; set; }
        public float Percentage { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("Beer ID: {0}\n", ID));
            sb.Append(String.Format("Beer name: {0}\n", Name));
            sb.Append(String.Format("Beer brand: {0}\n", Brand));
            sb.Append(String.Format("Beer type: {0}", Type));
            sb.Append(String.Format("Beer percentage: {0}%\n", Percentage));
            sb.Append(String.Format("Beer price: {0}dkk", Price));

            return sb.ToString();
        }
    }
}
