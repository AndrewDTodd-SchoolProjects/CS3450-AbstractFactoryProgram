using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class HighResFactory : IWidgetDocFactory
    {
        public IWidget CreateWidget()
        {
            return new HighResWidget();
        }

        public IDocument CreateDocument() 
        {
            return new HighResDocument();
        }
    }
}
