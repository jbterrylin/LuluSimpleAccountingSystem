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

        public PricePage(List<string> personlist, List<string> componentlist, List<Price> pricelist)
        {
            InitializeComponent();

            this.personlist = personlist;
            this.componentlist = componentlist;

            // header
            PricegridTB.Columns.Add("Component", "Component");
            PricegridTB.Columns["Component"].ReadOnly = true;
            foreach (var person in personlist)
            {
                pricegridTBAddColumn(new DataGridViewTextBoxColumn(), person, person);
            }

            // Action header (column)
            pricegridTBAddColumn(new DataGridViewButtonColumn(), "Action Btn", "Action Btn");
            pricegridTBAddColumn(new DataGridViewTextBoxColumn(), "Action TB", "Action TB");

            // for clone
            PricegridTB.Rows.Add(1);

            // action button row (for row)
            // set data row
            // if set button text
            // if pricelist have data, put it in
            foreach (var component in componentlist.Select((value, index) => new { value, index }))
            {
                DataGridViewRow row = (DataGridViewRow)PricegridTB.Rows[0].Clone();
                row.Cells[0].Value = component.value;
                row.Cells[row.Cells.Count - 2].Value = "Fill Empty Row With";
                PricegridTB.Rows.Add(row);
                if (pricelist.Count != 0)
                {
                    var filteredlist = pricelist.Where(price => price.component == component.value);
                    foreach (var price in filteredlist)
                    {
                        row.Cells[price.person].Value = price.price;
                    }
                }
            }

            // Action header (row)
            PricegridTB.Rows.Add(1);
            for (int i = 1; i < PricegridTB.ColumnCount - 2; i++)
            {
                DataGridViewButtonCell buttoncell = new DataGridViewButtonCell();
                PricegridTB.Rows[PricegridTB.Rows.Count - 1].Cells[i] = buttoncell;
                PricegridTB.Rows[PricegridTB.Rows.Count - 1].Cells[i].Value = "Fill Empty Column With";
            }
            PricegridTB.Rows[PricegridTB.Rows.Count - 1].Cells[0].Value = "Action Btn";
            PricegridTB.Rows.Add(1);
            PricegridTB.Rows[PricegridTB.Rows.Count - 1].Cells[0].Value = "Action TB";

            PricegridTB.CellClick += pricegridTBCellClick;
            PricegridTB.Rows.RemoveAt(0);
        }

        private void pricegridTBAddColumn(DataGridViewColumn type, string name, string header)
        {
            DataGridViewColumn column = type;
            column.Name = name;
            column.HeaderText = header;
            PricegridTB.Columns.Insert(PricegridTB.Columns.Count, column);
        }

        private void pricegridTBCellClick(object sender, DataGridViewCellEventArgs e)
        {
            // check pressedcell is action btn, if yes
            // check action tb is decimal or not, if yes
            // if that row or column is empty will fill with number in action tb
            // this can simpify but i think will be confusing, so i didn't simplify
            if (e.ColumnIndex == PricegridTB.Columns["Action Btn"].Index && PricegridTB.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value != null)
            {
                decimal result;
                if (!decimal.TryParse(PricegridTB.Rows[e.RowIndex].Cells[e.ColumnIndex+1].Value.ToString(), out result))
                {
                    MessageBox.Show("Your input in Action TB is not decimal.");
                }
                else
                {
                    for (int i=1; i< PricegridTB.ColumnCount-2; i++)
                    {
                        if (PricegridTB.Rows[e.RowIndex].Cells[i].Value == null || 
                            PricegridTB.Rows[e.RowIndex].Cells[i].Value.ToString() == "" ||
                            PricegridTB.Rows[e.RowIndex].Cells[i].Value.ToString()  == " ")
                        {
                            PricegridTB.Rows[e.RowIndex].Cells[i].Value = PricegridTB.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                        }
                    }
                }
            } else if (e.RowIndex == PricegridTB.RowCount-2 && PricegridTB.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value != null)
            {
                decimal result;
                if (!decimal.TryParse(PricegridTB.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value.ToString(), out result))
                {
                    MessageBox.Show("Your input in Action TB is not decimal.");
                }
                else
                {
                    for (int i = 0; i < PricegridTB.RowCount - 2; i++)
                    {
                        if (PricegridTB.Rows[i].Cells[e.ColumnIndex].Value == null ||
                            PricegridTB.Rows[i].Cells[e.ColumnIndex].Value.ToString() == "" ||
                            PricegridTB.Rows[i].Cells[e.ColumnIndex].Value.ToString() == " ")
                        {
                            PricegridTB.Rows[i].Cells[e.ColumnIndex].Value = PricegridTB.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString();
                        }
                    }
                }
            }
        }

        public List<Price> getPriceList()
        {
            // check inut is null or is decimal or not, if no
            // pass empty list, if yes
            foreach (var component in componentlist.Select((value, index) => new { value, index }))
            {
                foreach (var person in personlist)
                {
                    if (PricegridTB.Rows[component.index].Cells[person].Value == null)
                    {
                        MessageBox.Show("Some of your input is empty");
                        return new List<Price>();
                        //return new PricesListWithOk(false, null);
                    }
                    decimal result;
                    if (!decimal.TryParse(PricegridTB.Rows[component.index].Cells[person].Value.ToString(), out result))
                    {
                        MessageBox.Show("Some of your input is not decimal");
                        //return new PricesListWithOk(false, null);
                        return new List<Price>();
                    }
                }
            }

            // gather data, then
            List<Price> pricelist = new List<Price>();
            foreach (var component in componentlist.Select((value, index) => new { value, index }))
            {
                foreach (var person in personlist)
                {
                    pricelist.Add(new Price() { component = component.value, person = person, price = decimal.Parse(PricegridTB.Rows[component.index].Cells[person].Value.ToString()) });
                }
            }

            // close this page, show box, return list
            this.Close();
            MessageBox.Show("Price list have been save.");
            return pricelist;
        }

        // use to call main page call getPriceList
        public delegate void saveBtnEventHandler();

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveBtnEventHandler myDelegate = new saveBtnEventHandler(Form1.callGetPriceList);
            myDelegate();
        }
    }
}
