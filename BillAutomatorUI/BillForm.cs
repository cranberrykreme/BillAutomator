using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
//using BillAutomator;

namespace BillAutomatorUI
{
    /// <summary>
    /// This Form is the basic view that the user will see
    /// when they open a particular file or create a new one.
    /// It gives the user access to all of the other forms, 
    /// such as solicitor and counsel management and adding
    /// new entries and disbursements. Finally, it allows the
    /// user to edit the existing entries.
    /// </summary>
    public partial class BillForm : Form
    {
        public string fileLoc;
        Document doc;
        BillModel em = new BillModel();

        public BillForm()
        {
            InitializeComponent();
        }

        private void saveCloseButton_Click(object sender, EventArgs e)
        {
            try{
                doc.Close();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.Close();

        }

        public void runStartup(Document aDoc)
        {
            DashboardForm df = new DashboardForm();
            fileLoc = df.fileName;

            doc = aDoc;
            try
            {
                for (int tab = 2; tab < 3; tab++)
                {
                    Word.Table table = doc.Tables[tab];
                    Rows rows = table.Rows;
                    Columns cols = table.Columns;
                    for (int i = 2; i <= rows.Count; i++)
                    {
                        string ftxt = "";
                        SolicitorsModel sol = new SolicitorsModel();
                        for (int j = 1; j <= cols.Count; j++)
                        {
                            Cell cell = rows[i].Cells[j];
                            Range r = cell.Range;

                            string txt = r.Text;
                            ftxt = ftxt + " | " + txt;
                            if (tab == 2)
                            {
                                //TODO - what if some of these entries are empty? will it be picked up by the 
                                // try-catch block?
                                if (j == 1) // name
                                {
                                    try
                                    {
                                        string[] names = txt.Split(' ');
                                        string firstName = "";

                                        for (int loc = 0; loc < names.Length - 1; loc++)
                                        {
                                            firstName = firstName + names[loc] + " ";
                                        }
                                        int len = names.Length;
                                        string secondName = names[len - 1];

                                        sol.firstName = firstName;
                                        string lastName = secondName.Replace("", "");
                                        sol.lastName = lastName.Substring(0, lastName.Length - 1);
                                    } catch
                                    {
                                        Console.WriteLine("First and second name");
                                    }
                                    
                                }
                                else if (j == 2) // Initials
                                {
                                    try
                                    {
                                        string initials = txt.Replace("", "");
                                        sol.initials = initials.Substring(0,initials.Length - 1);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("initials");
                                    }
                                    
                                }
                                else if (j == 3) // Date of Admission
                                {
                                    try
                                    {
                                        string doa = txt.Replace("", "");
                                        sol.dateOfAdmission = doa.Substring(0, doa.Length - 1);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("date of admissions");
                                    }
                                    
                                }
                                else if(j == 4) // Hourly rate
                                {
                                    try
                                    {
                                        string rate = txt.Substring(1);
                                        //string rating = rate.Split(' ');
                                        string[] rating = rate.Split('.');
                                        //Console.WriteLine("|" + rate + "|");
                                        //Console.WriteLine(rate.Length);
                                        //Console.WriteLine(rating[0]);
                                        double hourly = Convert.ToDouble(rating[0]);
                                        //double hourly = 0.0;
                                        //Double.TryParse(rating[0], out hourly);
                                        Console.WriteLine("|" + hourly + "|");
                                        hourly = hourly + 0.00;
                                        List<double> rates = new List<double>();
                                        rates.Add(hourly);
                                        sol.hourlyRates = rates;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hourly Rate");
                                        Console.WriteLine(ex);
                                    }
                                    
                                }

                            }
                        }
                        em.solicitor.Add(sol);
                        //Console.WriteLine(ftxt + "\n");
                        
                    }
                }
                Console.WriteLine(em.solicitor);
                Console.WriteLine(em.solicitor.Count);
               // foreach(SolicitorsModel sm in em.solicitor)
                //{
                //    sm.hourlyRates.ForEach(Console.WriteLine);
                //}

                em.solicitor.ForEach(delegate (SolicitorsModel sm)
                {
                    //sm.hourlyRates.ForEach(Console.WriteLine);
                    Console.WriteLine(sm.initials);
                    Console.WriteLine(sm.initials.Length);
                    Console.WriteLine(sm.dateOfAdmission);
                    Console.WriteLine(sm.lastName);
                    sm.hourlyRates.ForEach(delegate (double hr)
                    {
                            Console.WriteLine(hr);
                    });
                });

                //em.solicitor.ForEach(Console.WriteLine);
                
                Word.Table tabs = doc.Tables[3];
                Rows row = tabs.Rows;
                Columns col = tabs.Columns;
                //iterate over rows
                for (int i = 2; i < row.Count; i++)
                {
                    string ftxt = "";
                    EntriesModel entries = new EntriesModel();
                    //iterate over columns
                    for (int j = 2; j <= col.Count; j++)
                    {
                        Cell cell = row[i].Cells[j];
                        Range r = cell.Range;

                        string txt = r.Text;
                        ftxt = ftxt + " | " + txt;
                        if (j == 2) // Date of the entry
                        {
                            try
                            {
                                string entryDate = txt.Replace("", "");
                                entryDate = entryDate.Substring(0, entryDate.Length - 1);
                                Console.WriteLine("The date in question: " + entryDate);
                                var parsedDate = DateTime.Parse(entryDate);
                                parsedDate = parsedDate.Date;
                                Console.WriteLine(parsedDate);
                                entries.date = parsedDate;

                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        } else if(j == 3) // Entries solicitor
                        { 
                            try
                            {
                                string solicitor = txt.Replace("", "");
                                solicitor = solicitor.Substring(0, solicitor.Length - 1);
                                Console.WriteLine(solicitor);
                                bool found = false;
                                int index = 0;

                                // Loop over the existing solicitor profiles
                                while(found == false && index < em.solicitor.Count)
                                {
                                    SolicitorsModel hold = em.solicitor[index];
                                    //Console.WriteLine("-------------------------");
                                    //Console.WriteLine(hold.initials);
                                    //Console.WriteLine(solicitor);
                                    //Console.WriteLine("-------------------------");
                                    if (String.Equals(hold.initials, solicitor))
                                    {
                                        found = true;
                                        entries.solicitor = hold;
                                    }
                                    index++;
                                }
                                // If there is still no solicitor found, put it down as empty
                                if(found != true)
                                {
                                    SolicitorsModel notFound = new SolicitorsModel();
                                    notFound.initials = "Not Found";
                                    entries.solicitor = notFound;
                                }

                                Console.WriteLine(entries.solicitor.initials);


                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        } else if(j == 4) // Entries description
                        {
                            try
                            {
                                string desc = txt.Replace("", "");
                                desc = desc.Substring(0, desc.Length - 1);
                                Console.WriteLine(desc);
                                entries.description = desc;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }


                        } else if (j == 5) // Price of the entry
                        {
                            try
                            {
                                string price = txt.Replace("", "");
                                price = price.Substring(1, price.Length - 1);
                                double amount = Convert.ToDouble(price);
                                Console.WriteLine(amount);
                                entries.amount = amount;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    em.entries.Add(entries); // Add the current row to the list of entries
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            em.entries.ForEach(delegate (EntriesModel entry)
            {
                entriesBox.Items.Add(entry.date + " - " + entry.solicitor.initials + " - " + 
                    entry.description);
            });

            // Set the name of the client and display on the form.
            string[] name = doc.Name.Split('-');
            string clientName = name[2];
            clientNameLabel.Text = clientName;
            clientNameLabel.Font = new System.Drawing.Font(clientNameLabel.Font, FontStyle.Bold);
        }

        private bool ValidateForm()
        {
            return true;
        }
    }
}
