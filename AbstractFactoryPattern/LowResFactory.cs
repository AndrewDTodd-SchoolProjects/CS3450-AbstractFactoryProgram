using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class LowResFactory : IWidgetDocFactory
    {
        public IWidget CreateWidget()
        {
            return new LowResWidget();
        }

        public IDocument CreateDocument() 
        {
            return new LowResDocument();
        }
    }
}
