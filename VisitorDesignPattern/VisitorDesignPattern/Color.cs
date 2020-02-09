using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    class Color : IAccept
    {
        public string color;
        public Color(string cl)
        {
            color = cl;
        }
        public string getColor()
        {
            return color;
        }

        public int Accept(IVisitor visitor)
        {
            return 0;
        }

        public double dbAccept(IVisitor visitor)
        {
            return 0;
        }

        public string strAccept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
