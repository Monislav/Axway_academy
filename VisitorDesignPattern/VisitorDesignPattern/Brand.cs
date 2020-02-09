using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    class Brand : IAccept
    {
        public string brand;
        public Brand(string name)
        {
            brand = name;
        }

        public int Accept(IVisitor visitor)
        {
            return 0;
        }

        public double dbAccept(IVisitor visitor)
        {
            return 0;
        }

        public string getBrand()
        {
            return brand;
        }

        public string strAccept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
