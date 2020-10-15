using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulu
{
    public class Price
    {
        [Name("person")]
        public string person { get; set; }
        [Name("component")]
        public string component { get; set; }
        [Name("price")]
        public decimal price { get; set; }
    }
}
