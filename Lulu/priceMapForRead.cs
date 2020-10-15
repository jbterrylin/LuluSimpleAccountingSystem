using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulu
{
    class priceMapForRead : ClassMap<Price>
    {
        public priceMapForRead()
        {
            Map(m => m.component).Name("component");
            Map(m => m.person).Name("person");
            Map(m => m.price).Name("price");
        }
    }
}
