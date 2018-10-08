using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.Entity
{
    public enum BeerType { Dark, Brown, Light}

    public class Beer
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public BeerType Type { get; set; }
        public float Percentage { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public uint Stock { get; set; }

        public Beer()
        {

        }

        public Beer(string name, string brand, BeerType type, float percentage, double price, string url, uint stock)
        {
            this.Name = name;
            this.Brand = brand;
            this.Type = type;
            this.Percentage = percentage;
            this.Price = price;
            this.ImageURL = url;
            this.Stock = stock;
        }

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
