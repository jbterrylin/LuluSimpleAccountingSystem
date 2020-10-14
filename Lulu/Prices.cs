using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulu
{
    public class Prices
    {
        public string person;
        public string component;
        public decimal price;
    }

    public class PricesListWithOk
    {
        public bool ok;
        public List<Prices> pricelist;

        public PricesListWithOk(bool ok, List<Prices> pricelist)
        {
            this.ok = ok;
            this.pricelist = pricelist;
        }
    }
}
