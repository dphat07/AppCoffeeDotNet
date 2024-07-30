using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class FoodCategory
    {
        int id;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public FoodCategory()
        {
            Id = 0;
            Name = "";
        }
        public FoodCategory(int id,string name)
        {
            this.Name = name;
            this.id = Id;
        }
    }
}
