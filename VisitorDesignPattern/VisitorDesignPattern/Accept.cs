using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    interface IAccept
    {
        int Accept(IVisitor visitor);
        double dbAccept(IVisitor visitor);
        string strAccept(IVisitor visitor);
    }
}
