using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern_Pizza.Topping;

namespace DesignPattern_Pizza
{
    public class MargheritaBase : ToppingDecorator
    {
        public MargheritaBase(IPizza pizza) : base(pizza)
        { 
        }

        public override string GetDescription()
        {
            return "Margerita pizza";
        }
        
        public override decimal GetPrice()
        {
            return 40;
        }
    }
}
