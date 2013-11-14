using System;
using System.Linq;

namespace Task1KnapsackProblem
{
    class Item
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public Item(string name, int weight, int price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Weight = " + Weight + ", Price = " + Price;
        }
    }
}
