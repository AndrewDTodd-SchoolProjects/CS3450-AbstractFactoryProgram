using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class LowResWidget : IWidget
    {
        public void Draw()
        {
            Console.WriteLine("Widget is being drawn with a Low Resolution Driver");
        }
    }
}
