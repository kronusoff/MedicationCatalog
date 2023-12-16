using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication
{
    public class Product
    {
        private int _id;
        private string _category;
        private string _name;
        private int _price;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Product(int id, string category, string name, int price)
        {
            ID = id;
            Category = category;
            Name = name;
            Price = price;
        }
    }

}
