using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal interface IWidgetDocFactory
    {
        public IWidget CreateWidget();
        public IDocument CreateDocument();
    }
}
