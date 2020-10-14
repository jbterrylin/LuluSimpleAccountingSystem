using System;
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

namespace Lulu
{
    public partial class Form1 : Form
    {
        public List<Pack> packlist = new List<Pack>();
        public Processor processor = null;
        public static PricePage pricepage = null;
        public static List<Prices> pricelist = null;

        public Form1()
        {
            InitializeComponent();
            DateTB.CustomFormat = "dd.MM.yyyy";
            this.ActiveControl = DateTB;
        }

        private void changeFocusThroughKeyboard(KeyEventArgs e, Control targetTB, Keys key)
        {
            if (e.KeyCode == key)
            {
                this.ActiveControl = targetTB;
                //e.Handled = true;
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

        private void QuanityTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                changeFocusThroughKeyboard(e, QuanityTB, Keys.Enter);
                packlist.Add(new Pack() { date = DateTB.Value.Date, component = ComponentTB.Text, person = PersonTB.Text, quantity = QuanityTB.Value });
                QuanityTB.Value = 0;
                updatePackListView();
                updatePackTreeView();
                return;
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
            if (ComponentTB.Text == null || ComponentTB.Text == "")
            {
                if (MessageBox.Show("Do you want the Component Name to be null?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else if (PersonTB.Text == null || PersonTB.Text == "")
            {
                if (MessageBox.Show("Do you want the Person Name to be null?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else if (QuanityTB.Value == 0)
            {
                if (MessageBox.Show("Do you want the quantity is 0?", "Alert",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            packlist.Add(new Pack() { date = DateTB.Value.Date, component = ComponentTB.Text, person = PersonTB.Text, quantity = QuanityTB.Value });
            this.ActiveControl = DateTB;
            ComponentTB.Text = "Part ";
            PersonTB.Text = null;
            QuanityTB.Value = 0;
            updatePackListView();
            updatePackTreeView();
        }

        private void updatePackListView()
        {
            PackListView.Items.Clear();
            foreach (var pack in packlist)
            {
                string[] row;
                row = new string[] {
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
                    }
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SaveLocationTB.Text))
            {
                MessageBox.Show("The link you write is not exist.");
                return;
            } else if (SaveLocationTB.Text.EndsWith("\\"))
            {
                MessageBox.Show("No need to put \\ on last word.");
                return;
            } else if (pricelist == null)
            {
                MessageBox.Show("Please input price by click price button");
                return;
            } else if (MessageBox.Show("Do you save and save to this link?", "Alert",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
                //} else if (Directory.Exists(SaveLocationTB.Text+ "\\PackData"))
                //{
                //    MessageBox.Show("PackData folder alr exist. Please delete or rename it.");
                //    return;
            }
            //Directory.CreateDirectory(SaveLocationTB.Text + "\\PackData");
            processor = new Processor(packlist, pricelist, SaveLocationTB.Text + "\\PackData");
        }

        private void PackListView_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            pricepage = new PricePage(packlist.Select(x => x.person).Distinct().ToList(), packlist.Select(x => x.component).Distinct().ToList());
            pricepage.Show();
        }

        public static void callGetPriceList()
        {
            pricelist = pricepage.getPriceList().pricelist;
            MessageBox.Show("Price list have been save.");
        }
    }
}
