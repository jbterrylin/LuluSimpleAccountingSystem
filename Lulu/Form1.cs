﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Globalization;

namespace Lulu
{
    public partial class Form1 : Form
    {
        public List<Pack> packlist = new List<Pack>();
        public Processor processor = Processor.GetInstance();
        public static PricePage pricepage = null;
        //public static DatePage datepage = null;
        public static List<Price> pricelist = new List<Price>();
        public decimal listindex = 0;

        public Form1()
        {
            InitializeComponent();
            DateTB.CustomFormat = "dd.MM.yyyy";
            this.ActiveControl = DateTB;


            var a = GetWeekOfMonth(new DateTime(2020, 12, 19));
            //Debug.WriteLine("--------------");
            //Debug.WriteLine(a.ToString());
            //Debug.WriteLine("--------------");
        }

        public int dateToOne(DateTime date)
        {
            var temp = date.DayOfWeek;
            if(temp == DayOfWeek.Monday)
            {
                return 1;
            } else if (temp == DayOfWeek.Tuesday)
            {
                return 2;
            }
            else if (temp == DayOfWeek.Wednesday)
            {
                return 3;
            }
            else if (temp == DayOfWeek.Thursday)
            {
                return 4;
            }
            else if (temp == DayOfWeek.Friday)
            {
                return 5;
            }
            else if (temp == DayOfWeek.Saturday)
            {
                return 6;
            } else
            {
                return 7;
            }
        }

        public int GetWeekOfMonth(DateTime date)
        {
            var temp = date;
            while(dateToOne(temp) != 7)
            {

            }
            var daynumber = dateToOne(date);


            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }


        private void changeFocusThroughKeyboard(KeyEventArgs e, Control targetTB, Keys key)
        {
            if (e.KeyCode == key)
            {
                this.ActiveControl = targetTB;
                //e.Handled = true;
                // cancel beep sound
                e.SuppressKeyPress = true;
            }
        }

        private void DateTB_KeyDown(object sender, KeyEventArgs e)
        {
            changeFocusThroughKeyboard(e, ComponentTB, Keys.Enter);
        }

        private void ComponentTB_KeyDown(object sender, KeyEventArgs e)
        {
            changeFocusThroughKeyboard(e, PersonTB, Keys.Enter);
        }

        private void PersonTB_KeyDown(object sender, KeyEventArgs e)
        {
            changeFocusThroughKeyboard(e, QuanityTB, Keys.Enter);
        }

        private bool soulfulThreeAsk()
        {
            // if fill all corectly, return true, else
            // ask component, person want to be null and quantity want to be 0, if yes return true
            // no return false
            if (ComponentTB.Text == null || ComponentTB.Text == "")
            {
                if (MessageBox.Show("Do you want the Component Name to be null?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            if (PersonTB.Text == null || PersonTB.Text == "")
            {
                if (MessageBox.Show("Do you want the Person Name to be null?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            if (decimal.Parse(QuanityTB.Text) == 0)
            {
                if (MessageBox.Show("Do you want the quantity is 0?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void trimString()
        {
            // trim string before save
            ComponentTB.Text = ComponentTB.Text.Trim();
            PersonTB.Text = PersonTB.Text.Trim();
            QuanityTB.Text = QuanityTB.Text.Trim();
        }

        private void QuanityTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                changeFocusThroughKeyboard(e, QuanityTB, Keys.Enter);

                decimal result;
                if (!decimal.TryParse(QuanityTB.Text.Trim(), out result))
                {
                    MessageBox.Show("Your input in Quanity TB is not decimal.");
                    return;
                }
                if (soulfulThreeAsk())
                {
                    trimString();
                    packlist.Add(new Pack() { date = DateTB.Value.Date, component = ComponentTB.Text, person = PersonTB.Text, quantity = decimal.Parse(QuanityTB.Text), listindex = listindex, listname = ListNameTB.Text });
                    updatePackListView();
                    updatePackTreeView();
                    return;
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                changeFocusThroughKeyboard(e, DateTB, Keys.Q);
                return;
            }
            else if (e.KeyCode == Keys.W)
            {
                changeFocusThroughKeyboard(e, ComponentTB, Keys.W);
                return;
            } else if (e.KeyCode == Keys.E)
            {
                changeFocusThroughKeyboard(e, PersonTB, Keys.E);
                return;
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (soulfulThreeAsk())
            {
                trimString();
                packlist.Add(new Pack() { date = DateTB.Value.Date, component = ComponentTB.Text, person = PersonTB.Text, quantity = decimal.Parse(QuanityTB.Text), listindex = listindex, listname = ListNameTB.Text });
                this.ActiveControl = DateTB;
                ComponentTB.Text = "Part ";
                PersonTB.Text = null;
                QuanityTB.Text = null;
                updatePackListView();
                updatePackTreeView();
            }
        }

        private void updatePackListView()
        {
            PackListView.Items.Clear();
            int no = 1;
            foreach (var pack in packlist.Where(w => w.listindex == listindex).ToList())
            {
                string[] row;
                row = new string[] {
                    no.ToString(),
                    pack.date.ToString("dd.MM.yyyy"),
                    pack.component.ToString(),
                    pack.person.ToString(),
                    pack.quantity.ToString()
                };
                var lvi = new ListViewItem(row)
                {
                    Tag = pack
                };
                PackListView.Items.Add(lvi);
                no++;
            }
            if(PackListView.Items.Count != 0)
            {
                PackListView.Items[PackListView.Items.Count - 1].EnsureVisible();
            }
        }

        private void updatePackTreeView()
        {
            PackTreeView.Nodes.Clear();
            var datelist = packlist.Select(x => x.date).Distinct();
            foreach (var date in datelist.Select((value, index) => new { value, index }))
            {
                PackTreeView.Nodes.Add(date.value.ToString("dd.MM.yyyy"));

                var componentlist = packlist.FindAll(pack => pack.date == (DateTime)date.value).Select(pack => pack.component).Distinct();
                foreach (var component in componentlist.Select((value, index) => new { value, index }))
                {
                    PackTreeView.Nodes[date.index].Nodes.Add(component.value);

                    var personlist = packlist.FindAll(pack => pack.date == (DateTime)date.value && pack.component == component.value.ToString()).Select(pack => pack.person).Distinct();
                    foreach (var person in personlist.Select((value, index) => new { value, index }))
                    {
                        PackTreeView.Nodes[date.index].Nodes[component.index].Nodes.Add(person.value);

                        var quantitylist = packlist.FindAll(pack => pack.date == (DateTime)date.value && pack.component == component.value.ToString() && pack.person == person.value.ToString()).Select(pack => pack.quantity).Distinct();
                        foreach (var quantity in quantitylist)
                        {
                            PackTreeView.Nodes[date.index].Nodes[component.index].Nodes[person.index].Nodes.Add(quantity.ToString());
                        }
                        PackTreeView.Nodes[date.index].Nodes[component.index].Nodes[person.index].Nodes.Add("N of unit: " + quantitylist.Count().ToString());
                    }
                }
            }
        }

        private void PackListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if ListView's row clicked, ask want to delete or not, yes then delete
            try
            {
                var selectedpack = (Pack)PackListView.SelectedItems[0].Tag;
                if (selectedpack != null)
                {
                    if (MessageBox.Show("Do you want delete this row?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    packlist.RemoveAt(
                        packlist.FindIndex(pack =>
                            pack.date == selectedpack.date &&
                            pack.component == selectedpack.component &&
                            pack.person == selectedpack.person &&
                            pack.quantity == selectedpack.quantity
                        )
                    );
                    updatePackListView();
                    updatePackTreeView();
                }
            }
            catch (Exception)
            {
            }
        }

        private void PriceBtn_Click(object sender, EventArgs e)
        {
            pricepage = new PricePage(packlist.Select(x => x.person).Distinct().ToList(), packlist.Select(x => x.component).Distinct().ToList(), pricelist);
            pricepage.Show();
        }

        public static void callGetPriceList()
        {
            // delegate thing
            pricelist = pricepage.getPriceList();
        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SaveLocationTB.Text))
            {
                MessageBox.Show("The link you write is not exist or no permit.");
                return;
            }
            else if (SaveLocationTB.Text.EndsWith("\\"))
            {
                MessageBox.Show("No need to put \\ on last word.");
                return;
            }
            else if (pricelist == null)
            {
                MessageBox.Show("Please input price by click price button");
                return;
            }
            else if (MessageBox.Show("Do you save and save to this link?", "Alert",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else if (Directory.Exists(SaveLocationTB.Text + "\\PackData"))
            {
                MessageBox.Show("PackData folder alr exist. Please delete or rename it.");
                return;
            }
            Directory.CreateDirectory(SaveLocationTB.Text + "\\PackData");
            processor.setValue(packlist, pricelist, SaveLocationTB.Text + "\\PackData");
            processor.process();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(SaveLocationTB.Text + "savepack.csv")  || File.Exists(SaveLocationTB.Text + "saveprice.csv"))
            {
                MessageBox.Show("savepack or saveprice alr exist that link alr. Please delete, rename or change path it.");
                return;
            }
            if (!Directory.Exists(SaveLocationTB.Text))
            {
                MessageBox.Show("The link you write is not exist or no permit.");
                return;
            }
            processor.setValue(packlist, pricelist, SaveLocationTB.Text);
            processor.save();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                processor.setValue(packlist, pricelist, SaveLocationTB.Text);
                var okformat = processor.checkLoadFormat(selectedFileName);
                if(okformat == FILETYPE.PACK)
                {
                    if (MessageBox.Show("Do you overwritecurrent value?", "Alert",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        packlist = processor.loadPackList(selectedFileName);
                    }
                    else
                    {
                        packlist = packlist.Concat(processor.loadPackList(selectedFileName)).ToList();
                    }
                } else if (okformat == FILETYPE.PRICE)
                {
                    pricelist = processor.loadPriceList(selectedFileName);
                } else
                {
                    MessageBox.Show("Data is wrong.");
                }
                
            }
            updatePackListView();
            updatePackTreeView();
        }

        private void listNameUpdate()
        {
            if(packlist.Where(w => w.listindex == listindex).ToList().Count != 0)
            {
                ListNameTB.Text = packlist.Where(w => w.listindex == listindex).ToList()[0].listname;
            } else
            {
                ListNameTB.Text = null;
            }
            ListLbl.Text = listindex.ToString();
            ListViewPageNumTB.Value = listindex;
        }

        private void LastListView_Click(object sender, EventArgs e)
        {
            if(listindex != 0)
            {
                listindex--;
                updatePackListView();
                listNameUpdate();
            }
        }

        private void ListViewPageNumTB_ValueChanged(object sender, EventArgs e)
        {
            listindex = ListViewPageNumTB.Value;
            updatePackListView();
            listNameUpdate();
        }

        private void NextListView_Click(object sender, EventArgs e)
        {
            listindex++;
            updatePackListView();
            listNameUpdate();
        }

        private void ListNameTB_TextChanged(object sender, EventArgs e)
        {
            packlist.Where(w => w.listindex == listindex).ToList().ForEach(s => s.listname = ListNameTB.Text);
        }

        private void DateBtn_Click(object sender, EventArgs e)
        {
            //datepage = new DatePage();
            //datepage.Show();
        }
    }
}
