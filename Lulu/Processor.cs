﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lulu
{
    public class Processor
    {
        List<Pack> packlist = null;
        List<Prices> pricelist = null;
        string savelink = null;

        public Processor(List<Pack> packlist, List<Prices> pricelist, string savelink)
        {
            this.packlist = packlist;
            this.savelink = savelink;
            this.pricelist = pricelist;

            var datelist = packlist.Select(x => x.date).Distinct();
            foreach (var date in datelist)
            {
                processPackDayBased(date);
            }
            Debug.WriteLine("Processor created");
            Debug.WriteLine(pricelist.Count);
            processPackComponentBased();
            processPackPeopleBased();
            processPackPaidBased();
            MessageBox.Show("Done Save.");
        }

        private void processPackDayBased(DateTime date)
        {
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.Delimiter = ",";
                
                var componentlist = packlist.FindAll(pack => pack.date == (DateTime)date).Select(pack => pack.component).Distinct();

                foreach (var component in componentlist)
                {
                    csvWriter.WriteField(component);
                    csvWriter.NextRecord();
                    csvWriter.WriteField("Quantity");
                    csvWriter.WriteField("Person");
                    csvWriter.NextRecord();
                    var personlist = packlist.FindAll(pack => pack.date == (DateTime)date && pack.component == component.ToString()).Select(pack => pack.person).Distinct();

                    foreach (var person in personlist)
                    {
                        var quantitylist = packlist.FindAll(pack => pack.date == (DateTime)date && pack.component == component.ToString() && pack.person == person.ToString()).Select(pack => pack.quantity).Distinct();

                        foreach (var quantity in quantitylist)
                        {
                            csvWriter.WriteField(quantity.ToString());
                            csvWriter.WriteField(person);
                            csvWriter.NextRecord();
                        }
                    }
                    csvWriter.NextRecord();
                    csvWriter.WriteField("Total");
                    csvWriter.WriteField(packlist.FindAll(pack => pack.date == (DateTime)date && pack.component == component.ToString()).Select(x => x.quantity).Sum());

                    csvWriter.NextRecord();
                    csvWriter.NextRecord();
                    csvWriter.NextRecord();
                    csvWriter.NextRecord();
                }

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                //Console.WriteLine(result);
                // Write the string to a file.
                StreamWriter file = new StreamWriter(savelink + "\\"+ date.ToString("dd.MM.yyyy")+".csv");
                file.WriteLine(result);
                file.Close();
                mem.Flush();
            }
        }

        private void processPackComponentBased()
        {
            var componentlist = packlist.Select(x => x.component).Distinct();

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            {
                foreach (var component in componentlist)
                {
                    var packlistfilteredsorted = packlist.FindAll(pack => pack.component == component.ToString()).OrderBy(pack => pack.person);

                    csvWriter.Configuration.Delimiter = ",";

                    csvWriter.WriteField(component);
                    csvWriter.NextRecord();

                    foreach (var pack in packlistfilteredsorted)
                    {
                        csvWriter.WriteField(pack.quantity);
                        csvWriter.WriteField(pack.person);
                        csvWriter.NextRecord();
                    }

                    csvWriter.NextRecord();
                    csvWriter.NextRecord();
                    csvWriter.NextRecord();
                }

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                //Console.WriteLine(result);
                // Write the string to a file.
                StreamWriter file = new StreamWriter(savelink + "\\" + "All.csv");
                file.WriteLine(result);
                file.Close();
                mem.Flush();
            }
        }

        private void processPackPeopleBased()
        {
            var componentlist = packlist.Select(x => x.component).Distinct();
            var personlist = packlist.Select(x => x.person).Distinct();
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.Delimiter = ",";

                csvWriter.WriteField("Person");
                csvWriter.NextRecord();
                csvWriter.NextRecord();
                csvWriter.WriteField("");
                foreach (var person in personlist)
                {
                    csvWriter.WriteField(person);
                    csvWriter.WriteField("");
                }
                csvWriter.NextRecord();
                foreach (var component in componentlist)
                {
                    csvWriter.WriteField(component);
                    var filteredcomponentlist = packlist.FindAll(pack => pack.component == component.ToString());
                    foreach (var person in personlist)
                    {
                        if(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Sum() == 0)
                        {
                            csvWriter.WriteField("");
                        } else
                        {
                            csvWriter.WriteField(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Sum());
                        }
                        if (filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Count() == 0)
                        {
                            csvWriter.WriteField("");
                        }
                        else
                        {
                            csvWriter.WriteField(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Count());
                        }
                    }
                    csvWriter.NextRecord();
                }

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                //Console.WriteLine(result);
                // Write the string to a file.
                StreamWriter file = new StreamWriter(savelink + "\\" + "ppl.csv");
                file.WriteLine(result);
                file.Close();
                mem.Flush();
            }
        }

        private void processPackPaidBased()
        {
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.Delimiter = ",";
                var componentlist = packlist.Select(x => x.component).Distinct();
                var personlist = packlist.Select(x => x.person).Distinct();

                csvWriter.WriteField("Person");
                csvWriter.NextRecord();

                var temppersonlist = new List<string>();

                csvWriter.WriteField("");
                foreach (var person in personlist)
                {
                    csvWriter.WriteField(person);
                    temppersonlist.Add(person);
                }
                csvWriter.NextRecord();

                var tempcomponentlist = pricelist.Select(x => x.component).Distinct();
                foreach (var component in tempcomponentlist)
                {
                    csvWriter.WriteField(component);
                    foreach (var person in temppersonlist)
                    {
                        csvWriter.WriteField(pricelist.Find(x => x.component == component && x.person == person).price);
                    }
                    csvWriter.NextRecord();
                }
                csvWriter.NextRecord();
                csvWriter.NextRecord();
                csvWriter.NextRecord();
                csvWriter.WriteField("");

                foreach (var person in personlist)
                {
                    csvWriter.WriteField(person);
                    csvWriter.WriteField("");
                }
                csvWriter.NextRecord();

                csvWriter.WriteField("Total:");
                foreach (var person in personlist)
                {
                    decimal totalprice = 0;

                    if (packlist.FindAll(pack => pack.person == person.ToString()).Count() == 0)
                    {
                        csvWriter.WriteField("");
                    }
                    else
                    {
                        //tempcomponentlist
                        var personindicomponentlist = packlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.component);
                        foreach (var component in personindicomponentlist)
                        {
                            decimal quantity = packlist.FindAll(pack => pack.person == person.ToString() && pack.component == component.ToString()).Select(x => x.quantity).Sum();
                            decimal price = pricelist.Find(pack => pack.person == person.ToString() && pack.component == component.ToString()).price;
                            totalprice += quantity * price;
                        }
                        csvWriter.WriteField(totalprice);
                        csvWriter.WriteField("");
                        //csvWriter.WriteField(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Sum());
                    }
                }

                csvWriter.NextRecord();

                foreach (var component in componentlist)
                {
                    csvWriter.WriteField(component);
                    var filteredcomponentlist = packlist.FindAll(pack => pack.component == component.ToString());
                    foreach (var person in personlist)
                    {
                        if (filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Sum() == 0)
                        {
                            csvWriter.WriteField("");
                        }
                        else
                        {
                            csvWriter.WriteField(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Sum());
                        }
                        if (filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Count() == 0)
                        {
                            csvWriter.WriteField("");
                        }
                        else
                        {
                            csvWriter.WriteField(filteredcomponentlist.FindAll(pack => pack.person == person.ToString()).Select(x => x.quantity).Count());
                        }
                    }
                    csvWriter.NextRecord();
                }
                

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                //Console.WriteLine(result);
                // Write the string to a file.
                StreamWriter file = new StreamWriter(savelink + "\\" + "Paid.csv");
                file.WriteLine(result);
                file.Close();
                mem.Flush();
            }
        }
    }
}
