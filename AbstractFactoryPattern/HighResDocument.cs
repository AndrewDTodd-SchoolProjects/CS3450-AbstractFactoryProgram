using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class HighResDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Document is being printed with a High Resolution Driver");
        }
    }
}
