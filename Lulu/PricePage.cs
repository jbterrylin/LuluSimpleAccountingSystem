using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lulu
{
    public partial class PricePage : Form
    {
        List<string> personlist = null;
        List<string> componentlist = null;

        public PricePage(List<string> personlist, List<string> componentlist)
        {
            InitializeComponent();

            this.personlist = personlist;
            this.componentlist = componentlist;

            PricegridTB.Columns.Add("Component", "Component");
            PricegridTB.Columns["Component"].ReadOnly = true;
            foreach (var person in personlist)
            {
                PricegridTB.Columns.Add(person, person);
            }
            foreach (var component in componentlist)
            {
                DataGridViewRow row = (DataGridViewRow)PricegridTB.Rows[0].Clone();
                row.Cells[0].Value = component;
                PricegridTB.Rows.Add(row);
            }

        }

        public PricesListWithOk getPriceList()
        {
            List<Prices> pricelist = new List<Prices>();
            foreach (var component in componentlist.Select((value, index) => new { value, index }))
            {
                foreach (var person in personlist)
                {
                    decimal result;
                    Debug.WriteLine(PricegridTB.Rows[component.index].Cells[person].Value.ToString());
                    if (!decimal.TryParse(PricegridTB.Rows[component.index].Cells[person].Value.ToString(), out result))
                    {
                        MessageBox.Show("Some of your input is not decimal");
                        return new PricesListWithOk(false, null);
                    }
                }
            }

            foreach (var component in componentlist.Select((value, index) => new { value, index }))
            {
                foreach (var person in personlist)
                {
                    pricelist.Add(new Prices() { component = component.value, person = person, price = decimal.Parse(PricegridTB.Rows[component.index].Cells[person].Value.ToString()) });
                }
            }

            return new PricesListWithOk(true, pricelist);
        }

        public delegate void saveBtnEventHandler();

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveBtnEventHandler myDelegate = new saveBtnEventHandler(Form1.callGetPriceList);
            myDelegate();
        }
    }
}
