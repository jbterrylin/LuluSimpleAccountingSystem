using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulu
{
    class packMapForRead : ClassMap<Pack>
    {
        public packMapForRead()
        {
            Map(m => m.date).Name("date");
            Map(m => m.component).Name("component");
            Map(m => m.person).Name("person");
            Map(m => m.quantity).Name("quantity");
            Map(m => m.listindex).Name("listindex");
            Map(m => m.listname).Name("listname");
        }
    }
}
