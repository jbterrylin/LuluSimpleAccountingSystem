using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulu
{
    public class Pack
    {
        [Name("date")]
        public DateTime date { get; set; }
        [Name("component")]
        public string component { get; set; }
        [Name("person")]
        public string person { get; set; }
        [Name("quantity")]
        public decimal quantity { get; set; }

        [Name("listindex")]
        public decimal listindex { get; set; }
        [Name("listname")]
        public string listname { get; set; }
    }
}
