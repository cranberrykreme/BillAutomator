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
        private static Document doc; //will always have the same value
        private static string clientName; //Will store the name of the client
        private BillModel em;

        public BillForm()
        {
            InitializeComponent();
        }

        private void saveCloseButton_Click(object sender, EventArgs e)
        {
            try{//try to close the application
                if(doc != null)
                {
                    doc.Close();
                }
                
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.Close();

        }

        // This will only be called if the user chooses and already,
        // existing bill of costs to open up and run. It will parse all
        // of the information from the bill and present it to the
        // user in the style set out in the forms.
        public void runStartup(Document aDoc)
        {
            DashboardForm df = new DashboardForm();
            fileLoc = df.fileName;
            em = new BillModel();
            SolicitorsModel s = new SolicitorsModel();

            //Initialise a solicitor's profile for "unknown".
            List<double> unknownRate = new List<double>();
            unknownRate.Add(0.0);
            s.hourlyRates = unknownRate;
            s.firstName = "Unknown";
            s.lastName = "Solicitor/Worker";
            s.initials = "Unknown";
            s.dateOfAdmission = "";

            em.solicitor.Add(s);

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

                                        sol.firstName = firstName.Substring(0, firstName.Length - 1);
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

                                        string[] rating = rate.Split('.');

                                        double hourly = Convert.ToDouble(rating[0]);

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


                em.solicitor.ForEach(delegate (SolicitorsModel sm)
                {

                    Console.WriteLine(sm.initials);
                    Console.WriteLine(sm.initials.Length);
                    Console.WriteLine(sm.dateOfAdmission);
                    Console.WriteLine(sm.lastName);
                    sm.hourlyRates.ForEach(delegate (double hr)
                    {
                            Console.WriteLine(hr);
                    });
                });
                
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

                                string[] descriptions = desc.Split('–'); //Split the entire description
                                
                                string[] descHours = descriptions[descriptions.Length - 1].Split(' '); //Split what comes after the hyphen
                                string hours = descHours[1]; //take just the double value for the hours
                                Console.WriteLine("Input hours is: " + hours + " Length of entry is: " + descriptions.Length);
                                entries.hours = Convert.ToDouble(hours); //Add the hours to the entry

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
                                price = price.Substring(0, price.Length - 1);
                                double amount = Convert.ToDouble(price);
                                Console.WriteLine("Value of the entry: " + amount);
                                Console.WriteLine("Actual Value: " + price);
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

            displayEntries();

            // Set the name of the client and display on the form.
            string[] name = doc.Name.Split('-');
            clientName = name[2];
            clientNameLabel.Text = clientName;
            clientNameLabel.Font = new System.Drawing.Font(clientNameLabel.Font, FontStyle.Bold);
        }

        private bool ValidateForm()
        {
            return true;
        }

        private void displayEntries()
        {
            entriesBox.Items.Clear();
            em.entries.ForEach(delegate (EntriesModel entry)
            {
                //Only get the date part of the dateTime entry
                string date = entry.date.ToString();
                string[] dates = date.Split(' ');
                date = dates[0];

                //Display the entry in the box
                entriesBox.Items.Add(date + " - " + entry.solicitor.initials + " - " +
                    entry.description);
            });
        }



        // Display only the entries from a certain date. Also not working. 
        private void displayEntries(DateTime date)
        {
            entriesBox.Items.Clear();
            bool firstHit = false;
            int i = -1;
            em.entries.ForEach(delegate (EntriesModel ent)
            {
                i++;
                //EntriesModel ent = em.entries[i];
                int diff = DateTime.Compare(date, ent.date);
                if (diff == 0 && !firstHit)
                {
                    firstHit = true;
                }
                //Display the relevant entries
                if (diff == 0)
                {
                    //Only get the date part of the dateTime entry
                    string dateOfEntry = ent.date.ToString();
                    string[] dates = dateOfEntry.Split(' ');
                    dateOfEntry = dates[0];

                    entriesBox.Items.Add(dateOfEntry + " - " + ent.solicitor.initials + " - " +
                    ent.description);
                }
                //If there are no more entries to display, return
                if (firstHit == true && diff != 0)
                {
                    return;
                }
            });
            if (!firstHit)
            {
                entriesBox.Items.Add("There are no current entries on this date.");
            }
        }

        private void displayAllEntriesButton_Click(object sender, EventArgs e)
        {
            dateTimeBox.Value = DateTime.Now;
            displayEntries();
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            NewEntryForm nef = new NewEntryForm();
            nef.setBillModel(em);
            nef.Show();
            this.Close();
        }

        // To run when moving backwards and forwards between forms.
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
            clientNameLabel.Text = clientName;
            clientNameLabel.Font = new System.Drawing.Font(clientNameLabel.Font, FontStyle.Bold);
            displayEntries();
            //MessageBox.Show("Client name is: " + clientName);
            //MessageBox.Show("Document is: " + doc.Name);
        }

        // To access the solicitor management form.
        private void solicitorButton_Click(object sender, EventArgs e)
        {
            SolicitorManagementForm smf = new SolicitorManagementForm();
            smf.setBillModel(em);
            smf.runSetUp();
            smf.Show();
            this.Close();
        }

        private void dateTimeBox_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Time was changed");
            DateTime dt = dateTimeBox.Value.Date;
            displayEntries(dt);
        }

        /// <summary>
        /// Connect to the selected entry and remove it from the list/Bill of costs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            if(entriesBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an entry to delete");
                return;
            }

            int selected = entriesBox.SelectedIndex;
            string chosenEntry = entriesBox.SelectedItem.ToString();
            string[] entryParams = chosenEntry.Split('-');
            string description = entryParams[entryParams.Length - 1];
            description = description.Substring(1);
            //MessageBox.Show(description);
            int i = -1;
            int index = -1;
            em.entries.ForEach(delegate (EntriesModel entry)
            {
                i++;
                if(String.Equals(entry.description, description))
                {
                    index = i;
                }
            });
            if(index > -1)
            {
                em.entries.RemoveAt(index);
                displayEntries();
                return;
            }
            MessageBox.Show("Cannot Find Entry");
        }

        /// <summary>
        /// Connect to the entry that has been selected and open the NewEntryForm,
        /// class to edit the selected entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editSelectedButton_Click(object sender, EventArgs e)
        {
            if (entriesBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an entry to edit");
                return;
            }

            int selected = entriesBox.SelectedIndex;
            string chosenEntry = entriesBox.SelectedItem.ToString();
            string[] entryParams = chosenEntry.Split('-');
            string description = entryParams[entryParams.Length - 1];
            description = description.Substring(1);
            //MessageBox.Show(description);
            int i = -1;
            int index = -1;
            em.entries.ForEach(delegate (EntriesModel entry)
            {
                i++;
                if (String.Equals(entry.description, description))
                {
                    index = i;
                    editSelected(index);
                    return;
                }
            });
            if(index < 0)
            {
                MessageBox.Show("Cannot find selected entry");
            }
            

        }

        private void editSelected(int index)
        {
            NewEntryForm nef = new NewEntryForm();
            nef.setExistingBillModel(em, true, index);
            nef.Show();
            this.Close();
        }
    }
}
