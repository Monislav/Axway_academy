using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    class Car
    {
        static void Main(string[] args)
        {
            CarInfo carInfo = new CarInfo();
            Year year = new Year(1999);
            Brand brand = new Brand("Opel");
            Price price = new Price(2300.55);
            Color color = new Color("Black");

            Console.WriteLine(brand.strAccept(carInfo));
            Console.WriteLine(year.Accept(carInfo));
            Console.WriteLine(color.strAccept(carInfo));
            Console.WriteLine(price.dbAccept(carInfo));

        }
    }
}
