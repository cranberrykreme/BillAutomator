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
        private static int solTable; //Stores the table number of the solicitor table
        private static int entTable; //Stores the table number of the entries table

        public BillForm()
        {
            InitializeComponent();
        }

        private void saveCloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(doc.Path);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("The word document is no longer open, so your work cannot be saved, please close and re-open the application");
                return;
            }
            
            if(doc == null)
            {
                MessageBox.Show("There is no word document open/connected");
                this.Close();
                return;
            }
            try{//try to close the application
                Word.Table tbl = doc.Tables[solTable];
                Rows rows = tbl.Rows;
                int numRows = rows.Count; //to compare the index of the row to the final index.
                Columns cols = tbl.Columns;
                int finalIndex = -1;

                //SOLICITORS SECTION.
                // Enter all of the solicitors into the word document.
                for(int i = 1; i < em.solicitor.Count; i++)
                {
                    int index = i + 1; //As the first entry will be on the second row of the table
                    if (index > numRows)
                    {
                        object oMissing = System.Reflection.Missing.Value;
                        rows.Add(ref oMissing);
                        numRows++;
                        
                    }
                    Console.WriteLine("Current Row is: " + index);
                    Console.WriteLine("Current Number of rows is: " + rows.Count);
                    Console.WriteLine("Current List Entry is: " + i + " And the total size of the list is: " + em.solicitor.Count);
                    rows[index].Cells[1].Range.Text = em.solicitor[i].firstName + " " + em.solicitor[i].lastName;
                    rows[index].Cells[2].Range.Text = em.solicitor[i].initials;
                    rows[index].Cells[3].Range.Text = em.solicitor[i].dateOfAdmission;
                    if (cols.Count > 3) //If not a solicitor client bill, add the hourly rate of the solicitor
                    {
                        rows[index].Cells[4].Range.Text = "$" + em.solicitor[i].hourlyRates[0].ToString() + ".00";
                    }
                    
                    finalIndex = index;
                }
                //Add one more index to finalIndex, so it doesn't delete the final entry.
                finalIndex++;

                //Delete all unused rows.
                while(finalIndex <= numRows)
                {
                    try
                    {
                        rows[finalIndex].Delete();
                        numRows--;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Final Index is: " + finalIndex + " and number of rows is: " + numRows);
                        break;
                    }
                }

                //BILL ENTRIES SECTION.
                //Enter all of the bill entries into the bill of costs.
                tbl = doc.Tables[entTable];
                rows = tbl.Rows;
                numRows = rows.Count; //to compare the index of the row to the final index.
                cols = tbl.Columns;
                finalIndex = -1;

                for (int i = 0; i < em.entries.Count; i++)
                {
                    int index = i + 2; //As the first entry will be on the second row of the table, two higher than the index in the list.
                    if (index > numRows - 2)
                    {
                        //For the entries we must always add only the second last row.
                        Console.WriteLine(rows.Count);
                        rows.Add(rows[rows.Count - 1]);
                        numRows++;
                    }

                    Console.WriteLine(em.entries[i].date.ToString("dd.MM.yyyy"));
                    rows[index].Cells[2].Range.Text = em.entries[i].date.ToString("dd.MM.yyyy");    //Add the entries' date.
                    rows[index].Cells[3].Range.Text = em.entries[i].solicitor.initials;             //Add the solicitors initials
                    rows[index].Cells[4].Range.Text = em.entries[i].description;                    //Add the entries' description.
                    
                    //Add the cost of the entry.
                    double cost = em.entries[i].amount;
                    string[] amt = cost.ToString().Split('.');

                    double decimalPt = Convert.ToDouble(amt[amt.Length - 1]);
                    if(cost%1 == 0)
                    {
                        Console.WriteLine(cost);
                        rows[index].Cells[5].Range.Text = "$" + em.entries[i].amount.ToString() + ".00";
                        Console.WriteLine(rows[index].Cells[5].Range.Text);
                    }
                    else
                    {
                        string[] numbers = em.entries[i].amount.ToString().Split('.');
                        Console.WriteLine(numbers[numbers.Length - 1]);
                        string num = numbers[numbers.Length - 1];
                        if(num.Length < 2)
                        {
                            rows[index].Cells[5].Range.Text = "$" + em.entries[i].amount.ToString() + "0";
                        }
                        else
                        {
                            rows[index].Cells[5].Range.Text = "$" + em.entries[i].amount.ToString();
                        }
                    }
                    finalIndex = index;
                }
                //Add one more index to finalIndex, so it doesn't delete the final entry.
                finalIndex++;

                //Delete all unused entries. Keep the very last row as that is the summary.
                while (finalIndex < numRows)
                {
                    try
                    {
                        rows[finalIndex].Delete();
                        numRows--;
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Final Index is: " + finalIndex + " and number of rows is: " + numRows);
                        break;
                    }
                    
                }

                tbl.Columns[1].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
                tbl.Columns[1].PreferredWidth = 6.9f;

                tbl.Columns[2].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
                tbl.Columns[2].PreferredWidth = 11.5f;

                tbl.Columns[3].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
                tbl.Columns[3].PreferredWidth = 8.9f;

                tbl.Columns[4].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
                tbl.Columns[4].PreferredWidth = 60.5f;

                tbl.Columns[5].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
                tbl.Columns[5].PreferredWidth = 12.0f;

                //Save and close document.
                //doc.Save();
                //doc.Close();

                //TODO: update the summary amount in the final row upon completion.
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                doc.Close();
            }
            //this.Close();
            MessageBox.Show("All done!");

        }

        // This will only be called if the user chooses and already,
        // existing bill of costs to open up and run. It will parse all
        // of the information from the bill and present it to the
        // user in the style set out in the forms.
        public void runStartup(Document aDoc, int aSolTable, int aEntTable)
        {
            DashboardForm df = new DashboardForm();
            fileLoc = df.fileName;
            em = new BillModel();
            SolicitorsModel s = new SolicitorsModel();

            solTable = aSolTable;
            entTable = aEntTable;

            //Initialise a solicitor's profile for "unknown".
            List<double> unknownRate = new List<double>();
            unknownRate.Add(0.0);
            s.hourlyRates = unknownRate;
            s.firstName = "Unknown";
            s.lastName = "Solicitor/Worker";
            s.initials = "xx";
            s.dateOfAdmission = "";

            em.solicitor.Add(s);

            doc = aDoc;
            try
            {
                // FOR THE SOLICITORS.
                for (int tab = solTable; tab < solTable + 1; tab++)
                {

                    Word.Table table = doc.Tables[tab];
                    Rows rows = table.Rows;
                    Columns cols = table.Columns;
                    for (int i = 2; i <= rows.Count; i++)
                    {
                        string ftxt = "";
                        SolicitorsModel sol = new SolicitorsModel();
                        bool isEmpty = true; // To catch if the cells are empty.
                        for (int j = 1; j <= cols.Count; j++)
                        {
                            Cell cell = rows[i].Cells[j];
                            Range r = cell.Range;

                            string txt = r.Text;
                            ftxt = ftxt + " | " + txt;
                            if (tab == solTable)
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
                                        if (!String.IsNullOrEmpty(sol.firstName))
                                        {
                                            isEmpty = false;
                                        }
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
                                        if (!String.IsNullOrEmpty(sol.initials))
                                        {
                                            isEmpty = false;
                                        }
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
                                        if (!String.IsNullOrEmpty(sol.dateOfAdmission))
                                        {
                                            isEmpty = false;
                                        }
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
                                //WHAT TO DO FOR HOURLY RATE FOR SOL/CLIENT BILL??
                                else if (cols.Count < 4)
                                {
                                    try
                                    {
                                        double hourly = 0.00;
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
                        if (!isEmpty)
                        {
                            em.solicitor.Add(sol);
                        }
                        
                        //Console.WriteLine(ftxt + "\n");
                        
                    }
                }
                Console.WriteLine(em.solicitor);
                Console.WriteLine(em.solicitor.Count);

                // For debugging purposes, will cause error if solicitor list is empty
                if(em.solicitor.Count > 0)
                {
                    em.solicitor.ForEach(delegate (SolicitorsModel sm)
                    {
                        Console.WriteLine("Next solicitor in list: ");
                        Console.WriteLine(sm.initials);
                        Console.WriteLine(sm.initials.Length);
                        Console.WriteLine(sm.dateOfAdmission);
                        Console.WriteLine(sm.lastName);
                        sm.hourlyRates.ForEach(delegate (double hr)
                        {
                            Console.WriteLine(hr);
                        });
                    });
                }



                // FOR THE ENTRIES.
                Word.Table tabs = doc.Tables[entTable];
                Rows row = tabs.Rows;
                Columns col = tabs.Columns;
                //iterate over rows
                for (int i = 2; i < row.Count; i++)
                {
                    string ftxt = "";
                    EntriesModel entries = new EntriesModel();
                    bool isEmpty = true;
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
                                if (!String.IsNullOrEmpty(entryDate))
                                {
                                    isEmpty = false;
                                }
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
                                        isEmpty = false; //update that the cell is not empty.
                                    }
                                    index++;
                                }
                                // If there is still no solicitor found, put it down as empty
                                if(found != true)
                                {
                                    //SolicitorsModel notFound = new SolicitorsModel();
                                    //notFound.initials = "Not Found";
                                    entries.solicitor = em.solicitor[0];
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

                                if (!String.IsNullOrEmpty(entries.description))
                                {
                                    isEmpty = false;
                                }

                                string[] descriptions = desc.Split('–'); //Split the entire description
                                
                                string[] descHours = descriptions[descriptions.Length - 1].Split(' '); //Split what comes after the hyphen
                                string hours = descHours[1]; //take just the double value for the hours
                                Console.WriteLine("Input hours is: " + hours + " Length of entry is: " + descriptions.Length);
                                entries.hours = Convert.ToDouble(hours); //Add the hours to the entry

                                //Get the percentage of the entry that is claimed.
                                string getPercent = descriptions[descriptions.Length - 1];
                                if (getPercent.Contains('%'))
                                {
                                    string[] percentages = getPercent.Split('%');
                                    string per = percentages[0];
                                    percentages = per.Split('(');
                                    per = percentages[percentages.Length - 1];

                                    double percentageClaimed = 100;
                                    try
                                    {
                                        percentageClaimed = Convert.ToDouble(per);
                                    } catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }

                                    entries.percentage = percentageClaimed;
                                    Console.WriteLine("The % claimed is: " + entries.percentage);
                                }
                                else
                                {
                                    entries.percentage = 100;
                                }

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

                                if (!String.IsNullOrEmpty(price))
                                {
                                    isEmpty = false;
                                }

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

                    //If at lease one of the cells in the row is not empty.
                    if (!isEmpty)
                    {
                        em.entries.Add(entries); // Add the current row to the list of entries
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                doc.Close();
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
            try
            {
                Console.WriteLine(doc.Path);
            }
            catch
            {
                MessageBox.Show("There is no open document, so your work will not be saved." +
                " Please close this window and open a new document.");
                return;
            }
            
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
            int index = entriesFindIndex(chosenEntry);
            
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
            int index = entriesFindIndex(chosenEntry);

            if(index < 0)
            {
                MessageBox.Show("Cannot find selected entry");
            }
            else
            {
                editSelected(index);
            }
            

        }

        /// <summary>
        /// Return the correct index of the selected entry that is given to this method.
        /// </summary>
        /// <param name="chosenEntry">
        /// An entry that is the string of what shows on the forms box.
        /// </param>
        /// <returns></returns>
        private int entriesFindIndex(string chosenEntry)
        {
            string[] entryParams = chosenEntry.Split('-');
            string description = "";

            int curr = 2;
            while (curr < entryParams.Length)
            {
                //If a hyphen has been taken out becuase of the search, put it back in.
                if(curr > 2)
                {
                    description = description + "-" + entryParams[curr];
                }
                //Else just continue and put in a normal description.
                else
                {
                    description = description + entryParams[curr];
                }
                curr++;
            }

            description = description.Substring(1);
            //MessageBox.Show(description);
            int i = -1;
            int index = -1;

            foreach(EntriesModel entry in em.entries)
            {
                i++;
                Console.WriteLine("Entries in the list:      |" + entry.description + "|");
                Console.WriteLine("Entry to be searched for: |" + description + "|");
                if (String.Equals(entry.description, description))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private void editSelected(int index)
        {
            NewEntryForm nef = new NewEntryForm();
            nef.setExistingBillModel(em, true, index);
            nef.Show();
            this.Close();
        }

        //Move the selected entry upwards/earlier.
        private void upButton_Click(object sender, EventArgs e)
        {
            //If nothing is selected, tell the user and return.
            if(entriesBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an entry to move upwards");
                return;
            }
            //If there is no room left to move the entry up.
            if (entriesBox.SelectedIndex == 0)
            {
                MessageBox.Show("Cannot move first entry further up the list.");
                return;
            }

            // Get the correct index of the selected item.
            string chosenEntry = entriesBox.SelectedItem.ToString();
            int selected = entriesFindIndex(chosenEntry);

            try
            {
                //Find if both entries are on the same date.
                DateTime selectedDate = em.entries[selected].date;
                DateTime previousDate = em.entries[selected - 1].date;
                int diff = DateTime.Compare(selectedDate, previousDate);

                // If the date is not the same, cannot move
                if (diff != 0)
                {
                    MessageBox.Show("Cannot move the entry to a different date. If you want to " +
                        "change the date please edit the selected entry." + " " + 
                        "selected date: " + selectedDate + " & previous date: " + previousDate);
                    return;
                }
                else
                {
                    EntriesModel hold = em.entries[selected];

                    em.entries[selected] = em.entries[selected - 1];
                    em.entries[selected - 1] = hold;
                }

                //Display the new list, on the selected date.
                displayEntries(selectedDate);
                dateTimeBox.Value = selectedDate;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //MessageBox.Show(entriesBox.SelectedItem.ToString() + " " + em.entries[selected].description);
        }

        //Move the selected entry downwards/later.
        private void downButton_Click(object sender, EventArgs e)
        {
            //If nothing is selected, tell the user and return.
            if (entriesBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an entry to move downwards");
                return;
            }
            //If there is no room left to move the entry down.
            if (entriesBox.SelectedIndex == (em.entries.Count - 1)){
                MessageBox.Show("Cannot move last entry further down the list.");
                return;
            }

            // Get the correct index of the selected item.
            string chosenEntry = entriesBox.SelectedItem.ToString();
            int selected = entriesFindIndex(chosenEntry);

            try
            {
                //Find if both entries are on the same date.
                DateTime selectedDate = em.entries[selected].date;
                DateTime nextDate = em.entries[selected + 1].date;
                int diff = DateTime.Compare(selectedDate, nextDate);

                // If the date is not the same, cannot move
                if (diff != 0)
                {
                    MessageBox.Show("Cannot move the entry to a different date. If you want to " +
                        "change the date please edit the selected entry." + " " +
                        "selected date: " + selectedDate + " & next date: " + nextDate);
                    return;
                }
                else
                {
                    EntriesModel hold = em.entries[selected];

                    em.entries[selected] = em.entries[selected + 1];
                    em.entries[selected + 1] = hold;
                }

                //Display the new list, on the selected date.
                displayEntries(selectedDate);
                dateTimeBox.Value = selectedDate;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //MessageBox.Show(entriesBox.SelectedItem.ToString() + " " + em.entries[selected].description);

        }

        private void entriesBox_doubleClick(object sender, EventArgs e)
        {
            if(entriesBox.SelectedIndex > -1)
            {
                string chosenEntry = entriesBox.SelectedItem.ToString();
                int selected = entriesFindIndex(chosenEntry);

                DateTime date = em.entries[selected].date;

                displayEntries(date);
            }
        }
    }
}
