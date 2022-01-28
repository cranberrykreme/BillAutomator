using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
//using Microsoft.VisualBasic;
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
        private static Document doc; //will always have the same value
        private static string fileName; //will always have the same value.
        private static string clientName; //Will store the name of the client
        private BillModel em;
        private static int solTable; //Stores the table number of the solicitor table
        private static int entTable; //Stores the table number of the entries table
        private bool openingNew = false; //Is a new form being opened upon the close of this form?
        private static int disTable; //Stores the table number of the disbursements table
        private bool currentlyEntries = true; //Is the display table set to disbursements or entries?

        public BillForm()
        {
            InitializeComponent();
        }

        private bool writeChanges()
        {
            bool success = true;

            Word.Table tbl = doc.Tables[solTable];
            Rows rows = tbl.Rows;
            int numRows = rows.Count; //to compare the index of the row to the final index.
            Columns cols = tbl.Columns;
            int finalIndex = -1;

            //Initialise Loading Form. 
            LoadingForm lf = new LoadingForm();
            lf.Show();
            lf.TopMost = true;

            int solList = em.solicitor.Count;
            int entryList = em.entries.Count;
            int disList = em.disbursements.Count;

            int totalList = solList + entryList + disList;
            lf.totalLoading(totalList);

            //SOLICITORS SECTION.
            try
            {
                // Enter all of the solicitors into the word document.
                for (int i = 1; i < em.solicitor.Count; i++)
                {
                    //Update loading bar for each new row.
                    lf.progressDisplay();

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

                    if (!String.IsNullOrEmpty(em.solicitor[i].firstName))
                    {
                        rows[index].Cells[1].Range.Text = em.solicitor[i].firstName + " " + em.solicitor[i].lastName;
                    }
                    else
                    {
                        rows[index].Cells[1].Range.Text = em.solicitor[i].lastName;
                    }

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
                while (finalIndex <= numRows)
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
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error has occured in the writing to the solicitor's table.");
                return false;
            }

            //BILL ENTRIES SECTION.
            try
            {
                //Enter all of the bill entries into the bill of costs.
                tbl = doc.Tables[entTable];
                rows = tbl.Rows;
                numRows = rows.Count; //to compare the index of the row to the final index.
                cols = tbl.Columns;
                finalIndex = -1;

                for (int i = 0; i < em.entries.Count; i++)
                {
                    //Update loading bar for each new row.
                    lf.progressDisplay();

                    int index = i + 2; //As the first entry will be on the second row of the table, two higher than the index in the list.
                    if (index > numRows - 2)
                    {
                        //For the entries we must always add only the second last row.
                        Console.WriteLine(rows.Count);
                        rows.Add(rows[rows.Count - 1]);
                        numRows++;
                    }

                    Console.WriteLine(em.entries[i].date.ToString("dd.MM.yy"));
                    rows[index].Cells[2].Range.Text = em.entries[i].date.ToString("dd.MM.yy");    //Add the entries' date.

                    if (!em.entries[i].isPhotocopy)
                    {
                        rows[index].Cells[3].Range.Text = em.entries[i].solicitor.initials;             //Add the solicitors initials
                    }
                    
                    rows[index].Cells[4].Range.Text = em.entries[i].description;                    //Add the entries' description.

                    //Add the cost of the entry.
                    double cost = em.entries[i].amount;
                    string[] amt = cost.ToString().Split('.');

                    double decimalPt = Convert.ToDouble(amt[amt.Length - 1]);
                    if (cost % 1 == 0)
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
                        if (num.Length < 2)
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
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Final Index is: " + finalIndex + " and number of rows is: " + numRows);
                        break;
                    }

                }


                // Disbursements section.
                try
                {
                    //Enter all of the bill disbursements into the bill of costs.
                    tbl = doc.Tables[disTable];
                    rows = tbl.Rows;
                    numRows = rows.Count; //to compare the index of the row to the final index.
                    cols = tbl.Columns;
                    finalIndex = -1;
                    int currentType = 0;
                    int currentDiff = 2; //the difference between the iterator number and the actual row we want to look at.

                    // Iterate through the entire list.
                    for(int i = 0; i < em.disbursements.Count; i++)
                    {
                        lf.progressDisplay();

                        int index = i + currentDiff;
                        finalIndex = index;

                        // Add new rows as is needed
                        if (index > numRows - 2)
                        {
                            //For the entries we must always add only the second last row.
                            Console.WriteLine(rows.Count);
                            rows.Add(rows[rows.Count - 1]);
                            numRows++;

                        }

                        

                        // If the current type is the same as the previous disbursement type.
                        if (em.disbursements[i].typeOfDisbursement.type.Equals(em.usedDisbursementTypes[currentType].type))
                        {
                            //rows.Add(index); // Add a new row where the new entry should be, will always have an index number.

                            int numList = rows[index].Cells[1].Range.ListFormat.CountNumberedItems();
                            Console.WriteLine("Number of numbered items: " + numList + " in row number: " + i);

                            // If there are no numbers in the left-hand most column, then set one there.
                            if (numList < 1)
                            {
                                rows[index].Cells[1].Range.ListFormat.ApplyNumberDefault();
                            }

                            Range rType = rows[index].Cells[2].Range;
                            rType.Font.Size = 9; //Set the font size to be 9

                            // Add disbursements date
                            rType.Text = em.disbursements[i].date.ToString("dd.MM.yy");

                            rType = rows[index].Cells[3].Range;
                            rType.Underline = WdUnderline.wdUnderlineNone; //Remove underline from the description

                            // Add disbursements description
                            rType.Text = em.disbursements[i].description;

                            // Add disbursements cost
                            double cost = em.disbursements[i].amount;
                            string[] amt = cost.ToString().Split('.');

                            double decimalPt = Convert.ToDouble(amt[amt.Length - 1]);
                            if (cost % 1 == 0)
                            {
                                Console.WriteLine(cost);
                                rows[index].Cells[4].Range.Text = "$" + em.disbursements[i].amount.ToString() + ".00";
                                Console.WriteLine(rows[index].Cells[4].Range.Text);
                            }
                            else
                            {
                                string[] numbers = em.disbursements[i].amount.ToString().Split('.');
                                Console.WriteLine(numbers[numbers.Length - 1]);
                                string num = numbers[numbers.Length - 1];
                                if (num.Length < 2)
                                {
                                    rows[index].Cells[4].Range.Text = "$" + em.disbursements[i].amount.ToString() + "0";
                                }
                                else
                                {
                                    rows[index].Cells[4].Range.Text = "$" + em.disbursements[i].amount.ToString();
                                }
                            }
                            
                        } else // If the current type is not the same type as the previous entry.
                        {
                            Console.WriteLine("Current Disbursement type: " + em.disbursements[i].typeOfDisbursement.type);
                            Console.WriteLine("What the previous disbursement was: " + em.usedDisbursementTypes[currentType].type);

                            while (!em.disbursements[i].typeOfDisbursement.type.Equals(em.usedDisbursementTypes[currentType].type)){
                                currentType++;
                            }
                            
                            currentDiff++;

                            //Add additional row.
                            rows.Add(rows[index]);
                            numRows++;

                            int numList = 0; // is there a number at the start of this row?

                            if (currentType > 1)
                            { 
                                //Add another additional row.
                                rows.Add(rows[index]);
                                numRows++;
                                
                                currentDiff++;

                                try
                                {
                                    numList = rows[index].Cells[1].Range.ListFormat.CountNumberedItems();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }


                                // If there are numbers in the left-hand most column, remove them.
                                if (numList > 0)
                                {
                                    rows[index].Cells[1].Range.ListFormat.ApplyNumberDefault();
                                }

                                index++; // iterate the index.

                            }

                            if (currentType >= em.usedDisbursementTypes.Count)
                            {
                                MessageBox.Show("Error with displaying disbursements by type");
                                return false;
                            }

                            numList = 0;

                            try
                            {
                                numList = rows[index].Cells[1].Range.ListFormat.CountNumberedItems();
                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            

                            // If there are numbers in the left-hand most column, remove them.
                            if (numList > 0)
                            {
                                rows[index].Cells[1].Range.ListFormat.ApplyNumberDefault();
                            }

                            // Add the information necessary.
                            Range rType = rows[index].Cells[3].Range;
                            rType.Underline = WdUnderline.wdUnderlineSingle;
                            rType.Text = em.disbursements[i].typeOfDisbursement.type;

                            i--; // Move the iterator backwards to re-do the same entry.


                        }

                    }

                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                finalIndex++;

                //Delete all unused entries. Keep the very last row as that is the summary.
                while (finalIndex < numRows && finalIndex > -1)
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



                // Add one more row of buffer between the final subtotal and the end of the disbursements.
                rows.Add(rows[numRows]);

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error has occured in the writing to the professional fee's table.");
                return false;
            }

            // Set disbursement's table widths
            tbl.Columns[1].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
            tbl.Columns[1].PreferredWidth = 7.7f;

            tbl.Columns[2].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
            tbl.Columns[2].PreferredWidth = 11.8f;

            tbl.Columns[3].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
            tbl.Columns[3].PreferredWidth = 67.4f;

            tbl.Columns[4].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
            tbl.Columns[4].PreferredWidth = 12.9f;

            // Reset table to entries table
            tbl = doc.Tables[entTable];

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

            lf.Close();

            return success;
        }

        private void saveCloseButton_Click(object sender, EventArgs e)
        {
            bool success = false;
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
                openingNew = true;
                this.Close();
                return;
            }

            //try to close the application
            try
            {

                //Write changes.
                success = writeChanges();

                if (success)
                {
                    //Save and close document.
                    doc.Save();
                    doc.Close();
                }
                else { 
                    MessageBox.Show("As an error has occured, the document will not close automatically.");
                }
                

                //TODO: update the summary amount in the final row upon completion.
            } catch (System.Runtime.InteropServices.COMException boxEx)
            {
                MessageBox.Show("An error has occured to do with open dialog boxes from some word file, " + 
                    "please check to make sure there are no open dialog boxes before you try again.\n\n" + 
                    "You can close the document and application yourself, but take note of your changes that " +
                   "have failed to save to the word document.");

                Console.WriteLine(boxEx);

                // Do not close document, instead give the user the chance to close it themselves.
                //doc.Close();
                return;
            } catch (Exception ex)
            {
                MessageBox.Show("An error has occured, you can close the document and application yourself, but take note of your changes that " +
                   "have failed to save to the word document.\n\n\n" + ex.ToString());

                // Do not close document, instead give the user the chance to close it themselves.
                //doc.Close();
                return;
            }

            if (success)
            {
                openingNew = true;
                this.Close();
            }
            
            MessageBox.Show("All done!");

        }

        // This will only be called if the user chooses and already,
        // existing bill of costs to open up and run. It will parse all
        // of the information from the bill and present it to the
        // user in the style set out in the forms.
        public void runStartup(Document aDoc, string aFileName, int aSolTable, int aEntTable, int aDisTable)
        {
            em = new BillModel();
            SolicitorsModel s = new SolicitorsModel();
            fileName = aFileName;
            doc = aDoc;

            solTable = aSolTable;
            entTable = aEntTable;
            disTable = aDisTable;

            if(solTable == 0 && entTable == 0 && disTable == 0)
            {
                //Determine which tables are which.
                solTable = findSolTable();
                entTable = findEntTable();
                disTable = findDisTable();
            }
            

            // If there has been some type of error.
            if(solTable == 0 || entTable == 0 || disTable == 0)
            {
                TableInputForm tif = new TableInputForm();
                tif.initialise(solTable, entTable, disTable, doc, fileName);
                tif.Show();

                //MessageBox.Show("something is wrong" + " Sol Table is: " + solTable + " & Ent table is: " + entTable);
                this.Close();
                return;

            }

            //Initialise a solicitor's profile for "unknown".
            List<double> unknownRate = new List<double>();
            unknownRate.Add(0.0);
            s.hourlyRates = unknownRate;
            s.firstName = "Unknown";
            s.lastName = "Solicitor/Worker";
            s.initials = "xx";
            s.dateOfAdmission = "";

            em.solicitor.Add(s);

            // Set the types of disbursements.
            setUnusedDisbursements();


            //Initialise Loading Form. 
            LoadingForm lf = new LoadingForm();
            lf.Show();
            lf.TopMost = true;

            Word.Table testTable = doc.Tables[solTable];
            int solTableLength = testTable.Rows.Count;
            testTable = doc.Tables[entTable];
            int entTableLength = testTable.Rows.Count;
            testTable = doc.Tables[disTable];
            int disTableLength = testTable.Rows.Count;

            int totalLength = solTableLength + entTableLength + disTableLength;
            lf.totalLoading(totalLength);


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
                        //Update loading bar for each new row.
                        lf.progressDisplay();
                        string ftxt = "";
                        SolicitorsModel sol = new SolicitorsModel();
                        bool isEmpty = true; // To catch if the cells are empty.

                        // If there is less than the proper number of columns.
                        if (cols.Count < 4)
                        {
                            switch (cols.Count)
                            {
                                case 3:
                                    try
                                    {

                                        // Hourly Rate.
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
                                    break;
                                case 2:
                                    try
                                    {
                                        // DOA.
                                        sol.dateOfAdmission = "";

                                        // Hourly Rate.
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
                                    break;
                                case 1:
                                    try
                                    {
                                        // Initials.
                                        sol.initials = "XX";

                                        // DOA.
                                        sol.dateOfAdmission = "";

                                        // Hourly Rate.
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
                                    break;
                            }
                        }

                        for (int j = 1; j <= cols.Count; j++)
                        {
                            // Read the cell into the string
                            Cell cell = rows[i].Cells[j];
                            Range r = cell.Range;

                            string txt = r.Text;

                            //find if there are only empty characters in the string, will make the program run many times faster in the event of empty cells.
                            string[] test = Regex.Split(txt, "\\s");
                            bool testFull = false;
                            for (int a = 0; a < test.Length; a++)
                            {
                                if (!String.IsNullOrEmpty(test[a]))
                                {
                                    testFull = true;
                                    break;
                                }
                            }
                            if (!testFull)
                            {
                                txt = "";
                            }

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

                                        if (!String.IsNullOrEmpty(firstName))
                                        {
                                            sol.firstName = firstName.Substring(0, firstName.Length - 1);
                                        }
                                        
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
                                else if(j == 4 && !String.IsNullOrEmpty(txt)) // Hourly rate
                                {
                                    try
                                    {
                                        // An attempt to split the cell string into sections, one section having no \ characters in it.
                                        string[] cellText = Regex.Split(txt, "\\s");
                                        int cellIndex = 0;
                                        while (String.IsNullOrEmpty(cellText[cellIndex]) && cellIndex < cellText.Length - 1)
                                        {
                                            cellIndex++;
                                        }
                                        txt = cellText[cellIndex];

                                        string rate = txt.Replace("$", "");

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
                                        Console.WriteLine("Hourly Rate has a big problem");
                                        Console.WriteLine(ex);

                                        double hourly = 0.00;
                                        List<double> rates = new List<double>();
                                        rates.Add(hourly);
                                        sol.hourlyRates = rates;
                                    }
                                    
                                }
                                
                                

                            }
                        }

                        //initially set solicitor to not have been changed yet.
                        sol.changed = false;

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
                try
                {
                    if (em.solicitor.Count > 1)
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
                } catch (Exception ex)
                {
                    MessageBox.Show("Error with reading solicitor's tables");
                    Console.WriteLine(ex);
                }
                




                // FOR THE ENTRIES.
                Word.Table tabs = doc.Tables[entTable];
                Rows row = tabs.Rows;
                Columns col = tabs.Columns;
                //iterate over rows
                for (int i = 2; i < row.Count; i++)
                {
                    //Update loading bar for each new row.
                    lf.progressDisplay();

                    string ftxt = "";
                    EntriesModel entries = new EntriesModel();
                    bool isEmpty = true; //Stores if the row is empty

                    entries.isPhotocopy = isPhotocopy(row[i]);

                    //iterate over columns
                    for (int j = 2; j <= col.Count; j++)
                    {
                        Cell cell = row[i].Cells[j];
                        Range r = cell.Range;

                        string txt = r.Text;
                        txt = txt.Replace("", "").Replace("\n", "");

                        //find if there are only empty characters in the string.
                        string[] test = Regex.Split(txt, "\\s");
                        bool testFull = false;
                        for (int a = 0; a < test.Length; a++)
                        {
                            if (!String.IsNullOrEmpty(test[a]))
                            {
                                testFull = true;
                                break;
                            }
                        }
                        if (!testFull)
                        {
                            txt = "";
                        }

                        ftxt = ftxt + " | " + txt;
                        // Iterate through the entries by cell. TODO - add differently to photocopy entries.
                        if (j == 2 && !String.IsNullOrEmpty(txt)) // Date of the entry
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
                        } else if((j == 3 && !String.IsNullOrEmpty(txt)) || j == 3 && entries.isPhotocopy) // Entries solicitor or photocopy
                        { 
                            try
                            {
                                if (!entries.isPhotocopy)
                                {
                                    string solicitor = txt.Replace("", "");
                                    solicitor = solicitor.Substring(0, solicitor.Length - 1);
                                    Console.WriteLine(solicitor);
                                    bool found = false;
                                    int index = 0;

                                    // Loop over the existing solicitor profiles
                                    while (found == false && index < em.solicitor.Count)
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
                                    if (found != true)
                                    {
                                        //SolicitorsModel notFound = new SolicitorsModel();
                                        //notFound.initials = "Not Found";
                                        entries.solicitor = em.solicitor[0];
                                    }

                                    Console.WriteLine(entries.solicitor.initials);
                                }

                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        } else if(j == 4 && !String.IsNullOrEmpty(txt)) // Entries description
                        {
                            try
                            {
                                entries.noCharge = false;
                                string desc = txt.Replace("", "");
                                desc = desc.Substring(0, desc.Length - 1);
                                Console.WriteLine(desc);
                                entries.description = desc;

                                if (!String.IsNullOrEmpty(entries.description))
                                {
                                    isEmpty = false;
                                }

                                string[] descriptions = desc.Split('–'); //Split the entire description

                                //If some hours have been entered into the description.
                                if (txt.Contains('–'))
                                {
                                    string[] descHours = descriptions[descriptions.Length - 1].Split(' '); //Split what comes after the hyphen
                                    string hours = descHours[1]; //take just the double value for the hours
                                    Console.WriteLine("Input hours is: " + hours + " Length of entry is: " + descriptions.Length);
                                    entries.hours = Convert.ToDouble(hours); //Add the hours to the entry
                                }
                                else
                                {
                                    entries.hours = 0;
                                }
                                

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
                                } else if(getPercent.Contains("No Charge"))
                                {
                                    entries.noCharge = true;
                                    entries.percentage = 100;
                                }
                                else
                                {
                                    entries.percentage = 100;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                Console.WriteLine("String that caused issue from description is: " + @txt + " and is it null or empty? " + String.IsNullOrEmpty(txt));
                            }


                        } else if (j == 5 && !String.IsNullOrEmpty(txt)) // Price of the entry
                        {
                            try
                            {
                                // An attempt to split the cell string into sections, one section having no \ characters in it.
                                string[] cellText = Regex.Split(txt, "\\s");
                                int cellIndex = 0;
                                while (String.IsNullOrEmpty(cellText[cellIndex]) && cellIndex < cellText.Length - 1)
                                {
                                    cellIndex++;
                                }
                                txt = cellText[cellIndex];



                                string price = txt.Replace("", "").Replace("$","");

                                //price = price.Substring(0, price.Length - 1);

                                if (!String.IsNullOrEmpty(price))
                                {
                                    isEmpty = false;
                                }

                                //convert the string to a double, being the price of the entry.
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

                    //entry has not been changed yet.
                    entries.changed = false;

                    //If at lease one of the cells in the row is not empty.
                    if (!isEmpty)
                    {
                        em.entries.Add(entries); // Add the current row to the list of entries
                    }
                    
                }


                // FOR THE DISBURSEMENTS.
                tabs = doc.Tables[disTable];
                row = tabs.Rows;
                col = tabs.Columns;

                //iterate over rows
                for (int i = 2; i < row.Count; i++)
                {
                    //Update loading bar for each new row.
                    lf.progressDisplay();

                    DisbursementsModel disbursement = new DisbursementsModel();
                    bool isEmpty = true; //Stores if the row is empty
                    bool isType = false; // is this row a disbursement subheading?

                    

                    //iterate over columns
                    for (int j = 2; j <= col.Count; j++)
                    {
                        Cell cell = row[i].Cells[j];
                        Range r = cell.Range;

                        string txt = r.Text;
                        txt = txt.Replace("", "").Replace("\n", "");
                        

                        //find if there are only empty characters in the string.
                        string[] test = Regex.Split(txt, "\\s");
                        bool testFull = false;
                        for (int a = 0; a < test.Length; a++)
                        {
                            if (!String.IsNullOrEmpty(test[a]))
                            {
                                testFull = true;
                                break;
                            }
                        }
                        // If is empty, set the string to be empty.
                        if (!testFull)
                        {
                            txt = "";
                        }

                        // If the date is not there in the row.
                        if(j == 2 && String.IsNullOrEmpty(txt))
                        {
                            Cell cellType = row[i].Cells[j+1]; // Get the contents of the description
                            Range rType = cellType.Range;
                            if(rType.Underline != Word.WdUnderline.wdUnderlineNone)
                            {
                                Console.WriteLine("It is underlined: " + rType.Text);

                                string text = rType.Text;

                                text = text.Replace("", "").Replace("\n", "").Replace("\r", "");

                                DisbursementTypeModel dtm = new DisbursementTypeModel();
                                dtm.type = text;
                                em.usedDisbursementTypes.Add(dtm);
                                isType = true;
                            }

                            
                        } 
                        else if(j == 2 && !String.IsNullOrEmpty(txt)) // Get the date.
                        {
                            isEmpty = false;

                            try
                            {
                                DateTime parsedDate = DateTime.Parse(txt);
                                parsedDate = parsedDate.Date;
                                Console.WriteLine(parsedDate);
                                disbursement.date = parsedDate;
                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        else if(j == 3 && !String.IsNullOrEmpty(txt)) // Get the description.
                        {
                            isEmpty = false;

                            try
                            {
                                string desc = txt;

                                desc = desc.Replace("\r", "");

                                disbursement.description = desc;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        else if(j == 4 && !String.IsNullOrEmpty(txt)) // Get the amount
                        {
                            isEmpty = false;

                            try
                            {
                                //convert the string to a double, being the price of the entry.
                                // An attempt to split the cell string into sections, one section having no \ characters in it.
                                string[] cellText = Regex.Split(txt, "\\s");
                                int cellIndex = 0;
                                while (String.IsNullOrEmpty(cellText[cellIndex]) && cellIndex < cellText.Length - 1)
                                {
                                    cellIndex++;
                                }
                                txt = cellText[cellIndex];



                                string price = txt.Replace("", "").Replace("$", "");

                                //price = price.Substring(0, price.Length - 1);

                                if (!String.IsNullOrEmpty(price))
                                {
                                    isEmpty = false;
                                }

                                //convert the string to a double, being the price of the entry.
                                double amount = Convert.ToDouble(price);
                                Console.WriteLine("Value of the entry: " + amount);
                                Console.WriteLine("Actual Value: " + price);
                                disbursement.amount = amount;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }

                    }

                    //If at lease one of the cells in the row is not empty.
                    if (!isEmpty && !isType)
                    {
                        disbursement.typeOfDisbursement = em.usedDisbursementTypes[em.usedDisbursementTypes.Count - 1];
                        em.usedDisbursementTypes[em.usedDisbursementTypes.Count - 1].numDisbursements = em.usedDisbursementTypes[em.usedDisbursementTypes.Count - 1].numDisbursements + 1; // Add another disbursement to this number.
                        em.disbursements.Add(disbursement); // Add the current row to the list of disbursements.
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
            try
            {
                string[] name = doc.Name.Split('-');
                clientName = name[name.Length - 2];
                clientNameLabel.Text = clientName;
                clientNameLabel.Font = new System.Drawing.Font(clientNameLabel.Font, FontStyle.Bold);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                doc.Close();
            }

            lf.Close();

        }

        private void displayEntries()
        {
            entriesBox.Items.Clear();
            currentlyEntries = true;
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
            currentlyEntries = true;
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
            if (entriesBox.SelectedIndex > -1)
            {
                int selected = entriesBox.SelectedIndex;
                string chosenEntry = entriesBox.SelectedItem.ToString();
                int index = entriesFindIndex(chosenEntry);
                try
                {
                    nef.setDateBox(em.entries[index].date);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            nef.Show();
            openingNew = true;
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
                " Please close this window and open a new document, or try the re-open word button on the bottom left of the screen.");
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
            openingNew = true;
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

            // If the user has selected a disbursement.
            if (!currentlyEntries)
            {
                deleteDisbursement(entriesBox.SelectedIndex, entriesBox.SelectedItem.ToString());
                return;
            }

            string chosenEntry = entriesBox.SelectedItem.ToString();
            int index = entriesFindIndex(chosenEntry);
            
            if(index > -1)
            {
                em.entries.RemoveAt(index);

                for(int i = index; i < em.entries.Count; i++)
                {
                    em.entries[i].changed = true;
                }

                displayEntries();
                return;
            }
            MessageBox.Show("Cannot Find Entry");
        }

        /// <summary>
        /// Deletes a selected disbursement.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="description"></param>
        public void deleteDisbursement(int index, string description)
        {
            int disIndex = findDisbursement(description);
            if (disIndex < 0)
            {
                MessageBox.Show("Cannot find selected disbursement entry.");
                return;
            }

            // Get the disbursement type and reduce it's count by one.
            string disType = em.disbursements[disIndex].typeOfDisbursement.type;
            bool deleteType = false;
            int i = -1;
            int disTypeIndex = -1;
            
            foreach(DisbursementTypeModel dtm in em.usedDisbursementTypes)
            {
                i++;

                // If we have found the right type of disbursement, reduce its count, and remove it from the used list if necessary.
                if (dtm.type.Equals(disType))
                {
                    dtm.numDisbursements = dtm.numDisbursements - 1;
                    disTypeIndex = i;
                    if(dtm.numDisbursements < 1)
                    {
                        deleteType = true;
                    }
                    break;
                }
            }


            if (deleteType && disTypeIndex > -1)
            {
                em.usedDisbursementTypes.RemoveAt(disTypeIndex);
            }


            em.disbursements.RemoveAt(disIndex);

            displayDisbursements();

        }

        /// <summary>
        /// Finds the location of the disbursement in the em.disbursements list 
        /// by matching the description.
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public int findDisbursement(string description)
        {
            int index = -1;

            string[] descriptions = description.Split('-');
            description = descriptions[descriptions.Length - 1].Substring(1);

            foreach(DisbursementsModel dm in em.disbursements)
            {
                Console.WriteLine(description);
                Console.WriteLine(dm.description);
                index++;
                if (dm.description.Equals(description))
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Opens the edit screen for a particular disbursement.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="description"></param>
        public void editDisbursement(int index, string description)
        {
            int disIndex = findDisbursement(description);
            if(disIndex < 0)
            {
                MessageBox.Show("Cannot find selected disbursement entry.");
                return;
            }
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

            // If the user has selected a disbursement.
            if (!currentlyEntries)
            {
                editDisbursement(entriesBox.SelectedIndex, entriesBox.SelectedItem.ToString());
                return;
            }

            string chosenEntry = entriesBox.SelectedItem.ToString();
            int index = entriesFindIndex(chosenEntry);

            if(index < 0)
            {
                MessageBox.Show("Cannot find selected entry");
            } else
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
            if (!currentlyEntries)
            {
                return -1;
            }

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
            openingNew = true;
            this.Close();
        }

        //Move the selected entry upwards/earlier.
        private void upButton_Click(object sender, EventArgs e)
        {
            if (!currentlyEntries)
            {
                return;
            }

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
            if (!currentlyEntries)
            {
                return;
            }

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
            if(entriesBox.SelectedIndex > -1 && currentlyEntries)
            {
                string chosenEntry = entriesBox.SelectedItem.ToString();
                int selected = entriesFindIndex(chosenEntry);

                DateTime date = em.entries[selected].date;

                displayEntries(date);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                Console.WriteLine(doc.Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("The word document is no longer open, so your work cannot be saved, please close and re-open the application");
                return;
            }

            if (doc == null)
            {
                MessageBox.Show("There is no word document open/connected");
                openingNew = true;
                this.Close();
                return;
            }

            //try to close the application
            try
            {

                //Write changes.
                success = writeChanges();
                if(!success)
                {
                    MessageBox.Show("As an error has occured, the document will not close automatically.");
                }

                //Save document
                doc.Save();


                //TODO: update the summary amount in the final row upon completion.
            }
            catch (System.Runtime.InteropServices.COMException boxEx)
            {
                MessageBox.Show("An error has occured to do with open dialog boxes from some word file, " +
                    "please check to make sure there are no open dialog boxes before you try again.\n\n" +
                    "You can close the document and application yourself, but take note of your changes that " +
                   "have failed to save to the word document.");

                Console.WriteLine(boxEx);

                // Do not close document, instead give the user the chance to close it themselves.
                //doc.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured, you can close the document and application yourself, but take note of your changes that " +
                   "have failed to save to the word document.\n\n\n" + ex.ToString());

                // Do not close document, instead give the user the chance to close it themselves.
                //doc.Close();
                return;
            }
            MessageBox.Show("All done!");
        }



        private void BillForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                if (MessageBox.Show("Are you sure you want to exit? All your unsaved work will be deleted.", "Exit Window Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void reOpenWordButton_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(doc.Path);
            }
            catch
            {
                try
                {
                    Application ap = new Application();
                    doc = ap.Documents.Open(fileName);
                    ap.Visible = true;
                } catch (Exception exception)
                {
                    MessageBox.Show("Cannot re-open word document.");
                    Console.WriteLine(exception);
                    Console.WriteLine(fileName);
                    return;
                }
            }
            Console.WriteLine(doc.Path);
        }

        /// <summary>
        /// To exit the billForm if there is an error.
        /// </summary>
        private void closeAll()
        {
            doc.Close();
            this.Close();
        }

        /// <summary>
        /// Finds the correct solicitors table
        /// </summary>
        private int findSolTable()
        {
            int tableNum = 0;
            int returnTable = 0;

            // Runs through all of the tables
            foreach(Word.Table table in doc.Tables)
            {
                tableNum++;
                // For solicitors table, if it is missing the Rate column.
                if(table.Columns.Count > 2 && table.Columns.Count < 4)
                {
                    Rows rows = table.Rows;
                    Cell firstCell = rows[1].Cells[1];
                    Cell secondCell = rows[1].Cells[2];
                    Cell thirdCell = rows[1].Cells[3];

                    Range first = firstCell.Range;
                    Range second = secondCell.Range;
                    Range third = thirdCell.Range;

                    string firstTxt = first.Text;
                    string secondTxt = second.Text;
                    string thirdTxt = third.Text;

                    if(firstTxt.Contains("Author") && secondTxt.Contains("Code") && thirdTxt.Contains("Date of Admission"))
                    {
                        returnTable = tableNum;
                        break;
                    }
                    
                } // For the solicitors table, if it has more than the basic three columns
                else if(table.Columns.Count > 3)
                {
                    Rows rows = table.Rows;
                    Cell firstCell = rows[1].Cells[1];
                    Cell secondCell = rows[1].Cells[2];
                    Cell thirdCell = rows[1].Cells[3];
                    Cell fourthCell = rows[1].Cells[4];

                    Range first = firstCell.Range;
                    Range second = secondCell.Range;
                    Range third = thirdCell.Range;
                    Range fourth = fourthCell.Range;

                    string firstTxt = first.Text;
                    string secondTxt = second.Text;
                    string thirdTxt = third.Text;
                    string fourthTxt = fourth.Text;

                    if (firstTxt.Contains("Author") && secondTxt.Contains("Code") && thirdTxt.Contains("Date of Admission") && fourthTxt.Contains("Rate"))
                    {
                        returnTable = tableNum;
                        break;
                    }
                }
            }
            return returnTable;
        }

        /// <summary>
        /// Returns the correct table that has all of the entries in it.
        /// </summary>
        /// <returns></returns>
        private int findEntTable()
        {
            int foundTable = 0;
            for(int i = solTable + 1; i <= doc.Tables.Count; i++)
            {
                Table table;
                try
                {
                    table = doc.Tables[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Table " + i + " out of " + doc.Tables.Count);
                    break;
                }
                
                if(table.Columns.Count > 4)
                {
                    Rows rows = table.Rows;
                    Cell firstCell = rows[1].Cells[2];
                    Cell secondCell = rows[1].Cells[3];
                    Cell thirdCell = rows[1].Cells[4];
                    Cell fourthCell = rows[1].Cells[5];

                    Range first = firstCell.Range;
                    Range second = secondCell.Range;
                    Range third = thirdCell.Range;
                    Range fourth = fourthCell.Range;

                    string firstTxt = first.Text;
                    string secondTxt = second.Text;
                    string thirdTxt = third.Text;
                    string fourthTxt = fourth.Text;

                    if(firstTxt.Contains("Date") && secondTxt.Contains("Author") && thirdTxt.Contains("Description of Work Performed") && fourthTxt.Contains("Amount"))
                    {
                        foundTable = i;
                        break;
                    }
                }
                
            }

            return foundTable;
        }

        /// <summary>
        /// Returns the table with the disbursements in it.
        /// </summary>
        /// <returns></returns>
        private int findDisTable()
        {
            int foundTable = 0;

            // Iterate through all of the tables starting with the first table after the entries table.
            for(int i = entTable+1; i <= doc.Tables.Count; i++)
            {
                Table table;
                try
                {
                    table = doc.Tables[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Table " + i + " out of " + doc.Tables.Count);
                    break;
                }

                // Search for the correct table, the disbursements table.
                if (table.Columns.Count > 3)
                {
                    Rows rows = table.Rows;
                    Cell firstCell = rows[1].Cells[2];
                    Cell secondCell = rows[1].Cells[3];
                    Cell thirdCell = rows[1].Cells[4];

                    Range first = firstCell.Range;
                    Range second = secondCell.Range;
                    Range third = thirdCell.Range;

                    string firstTxt = first.Text;
                    string secondTxt = second.Text;
                    string thirdTxt = third.Text;

                    // Check if the table has all of the right parameters
                    if (firstTxt.Contains("Date") && secondTxt.Contains("Description of Work Performed") && thirdTxt.Contains("Amount"))
                    {
                        foundTable = i;
                        break;
                    }
                }
            }

            return foundTable;
        }

        private void setUnusedDisbursements()
        {
            DisbursementTypeModel dtm = new DisbursementTypeModel();
            dtm.type = "court fees";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "senior counsel";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "junior counsel";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "counsel";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "expert fees";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "medical report fees";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "service fees";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "agency fees";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "witness expenses";
            em.unusedDisbursementTypes.Add(dtm);

            dtm = new DisbursementTypeModel();
            dtm.type = "miscellaneous fees";
            em.unusedDisbursementTypes.Add(dtm);

            // Add one basic one to the used disbursements model.
            dtm = new DisbursementTypeModel();
            dtm.type = "Unknown";
            em.usedDisbursementTypes.Add(dtm);

        }

        /// <summary>
        /// Searches for photocopy statements in the description. 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isPhotocopy(Word.Row row)
        {
            Cell cell = row.Cells[4];
            Range r = cell.Range;

            string txt = r.Text;
            txt = txt.ToLower();

            if(txt.Contains("photocopied pages") || txt.Contains("coloured copies") || txt.Contains("printed copies"))
            {
                return isSolEmpty(row);
            }
            return false;
        }

        /// <summary>
        /// Finds out if the solicitors entry is blank in the row that is probably a photocopy entry.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isSolEmpty(Word.Row row)
        {
            Cell cell = row.Cells[3];
            Range r = cell.Range;

            string txt = r.Text;

            //find if there are only empty characters in the string.
            string[] test = Regex.Split(txt, "\\s");
            bool testFull = false;
            for (int a = 0; a < test.Length; a++)
            {
                if (!String.IsNullOrEmpty(test[a]))
                {
                    testFull = true;
                    break;
                }
            }
            if (testFull)
            {
                return true;
            }
            return false;
        }

        private void newDisbursementButton_Click(object sender, EventArgs e)
        {
            DisbursementForm df = new DisbursementForm();
            df.setBillModel(em);
            df.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// When the button is clicked to display the disbursements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayAllDisbursementsButton_Click(object sender, EventArgs e)
        {
            displayDisbursements();
        }

        /// <summary>
        /// Clears the displaybox and shows only the disbursements.
        /// </summary>
        private void displayDisbursements()
        {
            entriesBox.Items.Clear();
            currentlyEntries = false;
            string type = "";
            em.disbursements.ForEach(delegate (DisbursementsModel dm)
            {
                //Only get the date part of the dateTime entry
                string date = dm.date.ToString();
                string[] dates = date.Split(' ');
                date = dates[0];

                //Find if the type of this disbursement is the same as the previous one.
                string dmType = dm.typeOfDisbursement.type;
                if (!type.Contains(dmType))
                {
                    type = dmType;

                    entriesBox.Items.Add(dmType.ToUpper());
                }

                //Display the entry in the box
                entriesBox.Items.Add(date + " - " + dm.description);
            });

            em.usedDisbursementTypes.ForEach(delegate (DisbursementTypeModel dtm)
            {
                entriesBox.Items.Add(dtm.type.ToUpper() + " - " + dtm.numDisbursements);
            });
        }
    }
}
