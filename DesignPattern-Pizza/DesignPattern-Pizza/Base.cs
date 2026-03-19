using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Pizza
{
    public class Base : IPizza
    {
        public string GetDescription()
        {
            return "";
        }

        public decimal GetPrice()
        {
            return 0;
        }
    }
}
