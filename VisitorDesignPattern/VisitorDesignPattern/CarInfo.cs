using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    class CarInfo : IVisitor
    {
        public CarInfo()
        {

        }
        public int Visit(Year carYear)
        {
            Console.WriteLine("Car year:");
            return carYear.year;
        }

        public string Visit(Brand carBrand)
        {
            Console.WriteLine("Car brand:");
            return carBrand.brand;
        }

        public double Visit(Price carPrice)
        {
            Console.WriteLine("Car price:");
            return carPrice.price;
        }

        public string Visit(Color carColor)
        {
            Console.WriteLine("Car color:");
            return carColor.color;
        }
    }
}
