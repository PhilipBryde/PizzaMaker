using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesignPattern_Pizza
{
    public class DescriptionObserver : IObserver
    {
        TextBlock _label;

        public DescriptionObserver(TextBlock label)
        {
            _label = label;
        }

        public void Update(IPizza pizza)
        {
            _label.Text = pizza.GetDescription();
        }
    }
}
