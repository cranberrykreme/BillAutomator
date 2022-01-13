using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillAutomatorUI
{
    /// <summary>
    /// Form that allows the user to enter a new time 
    /// entry into the bill, links up with solicitors
    /// profiles to get the hourly rate and takes the 
    /// description as a string to add to the bill.
    /// </summary>
    public partial class NewEntryForm : Form
    {
        private BillModel em;
        private double hourlyRate = 0;
        SolicitorsModel workingSolicitor;
        bool exists = false;
        int existingIndex = -1;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?

        public NewEntryForm()
        {
            InitializeComponent();
        }

        // Set up the new entry form, fill out the drop-down with solicitors
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
            em.solicitor.ForEach(delegate (SolicitorsModel sm)
            {
                solicitorDropDown.Items.Add(sm.firstName + " " + sm.lastName);
            });
            percentageClaimedTextBox.Value = 100;
            descriptionTextBox.Text = " – 0.0 hours";
        }

        // Set up the new entry form, if it is editing an entry that already exists.
        public void setExistingBillModel(BillModel aEm, bool aExists, int index)
        {
            exists = aExists;
            existingIndex = index;
            em = aEm;

            EntriesModel existingEntry = em.entries[existingIndex];

            string names = String.Concat(existingEntry.solicitor.firstName, existingEntry.solicitor.lastName);
            int i = -1;
            int indexOfSol = -1;
            em.solicitor.ForEach(delegate (SolicitorsModel sm)
            {
                i++;
                solicitorDropDown.Items.Add(sm.firstName + " " + sm.lastName);
                string currentNames = String.Concat(sm.firstName, sm.lastName);
                Console.WriteLine(currentNames);
                Console.WriteLine(names);
                if(String.Equals(names, currentNames))
                {
                    Console.WriteLine("This is the correct sol");
                    indexOfSol = i;
                }
            });

            try
            {
                dateTimeBox.Value = existingEntry.date;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            descriptionTextBox.Text = existingEntry.description;
            hoursInput.Value = Convert.ToDecimal(existingEntry.hours);
            percentageClaimedTextBox.Value = Convert.ToDecimal(existingEntry.percentage);

            if(indexOfSol > -1)
            {
                solicitorDropDown.SelectedIndex = indexOfSol;
            }
            
        }

        private void cancelEntryButton_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// Retrieve the location in the bill for the entry to be entered into.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        private int enterEntry(EntriesModel ent)
        {
            //bool foundDate = false;
            bool afterDate = false;
            int i = -1;
            int index = -1;
            // Get the correct date and location to add the new entry to in the list.
            em.entries.ForEach(delegate (EntriesModel entry)
            {
                
                i++;
                int diff = DateTime.Compare(entry.date, ent.date);

                if (diff > 0 && !afterDate) // if new entry is earlier than this date it will be > 0
                {
                    afterDate = true;
                    //MessageBox.Show("Your entery has date: " + ent.date + " and should be entered right before " + entry.date
                    //    + " " + i);
                    Console.WriteLine(ent.date + " " + ent.description + " " + ent.amount + " " + ent.solicitor);
                    //em.entries.Insert(i, ent);
                    index = i;
                }

            });
            if (!afterDate)
            {
                //MessageBox.Show("Is never before the next date");
                Console.WriteLine(ent.date + " " + ent.description + " " + ent.amount + " " + ent.solicitor);
                em.entries.Add(ent);
                return -1;
            }
            else
            {
                return index;
            }
        }

        // Retrieves all of the relvant information, and has it entered into the bill.
        private void createEntryButton_Click(object sender, EventArgs e)
        {
            EntriesModel ent = new EntriesModel();
            updateDescription();
            //Find all of the relevant peices of data.
            try
            {
                try //Fill in the correct date for an entry.
                {
                    DateTime dt = dateTimeBox.Value.Date;
                    ent.date = dt;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Please choose a date");
                    return;
                }

                try //Description box
                {
                    String desc = descriptionTextBox.Text;
                    ent.description = desc;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Please fill in the description box.");
                    return;
                }

                try //Hours Input
                {
                    decimal hours = hoursInput.Value;
                    ent.hours = Decimal.ToDouble(hours);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Please fill in the amount of hours.");
                    return;
                }

                // Add the solicitor
                if(workingSolicitor == null)
                {
                    workingSolicitor = em.solicitor.First();
                }
                ent.solicitor = workingSolicitor;

                try
                {
                    decimal amount = totalInput.Value;
                    ent.amount = Decimal.ToDouble(amount);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("Please fill in the total amount");
                    return;
                }

                // Set the percentage claimed.
                try
                {
                    decimal perc = percentageClaimedTextBox.Value;
                    ent.percentage = Decimal.ToDouble(perc);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Please Fill in all of the relevant sections before creating entry");
            }

            if (!exists) //If making a new entry, add at the correct location.
            {
                int i = enterEntry(ent);
                if (i > -1)
                {
                    em.entries.Insert(i, ent);
                }
            } else //change an existing entry.
            {
                DateTime previousDate = em.entries[existingIndex].date;
                em.entries[existingIndex] = ent;
                DateTime newDate = em.entries[existingIndex].date;
                int diff = DateTime.Compare(previousDate, newDate);
                if (diff != 0)
                {
                    em.entries.RemoveAt(existingIndex);
                    int i = enterEntry(ent);
                    if(i > -1)
                    {
                        em.entries.Insert(i, ent);
                    }
                }
                
            }
            
            

            //Send user back to the bill form.
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// When a user inputs the hours into the entry form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hoursInput_valueChanged(object sender, EventArgs e)
        {
            //Work on automatically changing the total amount.
            if (hourlyRate > 0 && hoursInput.Value >= 0 && percentageClaimedTextBox.Value > 0)
            {
                double timeSpent = Decimal.ToDouble(hoursInput.Value);
                double perc = Decimal.ToDouble(percentageClaimedTextBox.Value);
                perc = perc / 100.00;
                totalInput.Value = Convert.ToDecimal(hourlyRate * timeSpent * perc);
                gstInput.Value = totalInput.Value / 10;
            }
            if (!String.IsNullOrEmpty(descriptionTextBox.Text) && !turnOffHoursCheckBox.Checked)
            {
                try
                {
                    //Work on automatically changing the number of hours in the description
                    updateDescription();
                    string[] descriptions = descriptionTextBox.Text.Split('–');
                    string hours = descriptions[descriptions.Length - 1];
                    string[] splitHours = hours.Split(' ');

                    splitHours = splitHours.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    double amountHours = Decimal.ToDouble(hoursInput.Value);
                    string time = amountHours.ToString();

                    splitHours[0] = time;
                    hours = String.Join(" ", splitHours);
                    hours = " " + hours;
                    descriptions[descriptions.Length - 1] = hours;

                    string desc = String.Join("–", descriptions);

                    descriptionTextBox.Text = desc;
                } catch
                {
                    MessageBox.Show("Please have the description box in the format \"... - x.x hours ...\"");
                }

            }


        }

        /// <summary>
        /// Changes all short hyphens into long hypens in the description box (where gramatically correct).
        /// </summary>
        private void updateDescription()
        {
            descriptionTextBox.Text = descriptionTextBox.Text.Replace(" - ", " – ");
        }
        /// <summary>
        /// Handles when the solictors drop down menu has been changed.
        /// Rather when the chosen solicitor has been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solicitorDropDown_valueChanged(object sender, EventArgs e)
        {

            // Get solicitors first and last names.
            string chosenSol = solicitorDropDown.Text;

            string[] names = chosenSol.Split(' ');
            string firstName = "";

            for (int loc = 0; loc < names.Length - 1; loc++)
            {
                firstName = firstName + " " + names[loc];
            }

            String testName = firstName.Substring(1);
            if (String.IsNullOrEmpty(testName))
            {
                firstName = null;
            }
            else
            {
                firstName = firstName.Substring(1);
            }

            
            int len = names.Length;
            string secondName = names[len - 1];

            bool found = false;
            // Match names to solicitor profiles
            em.solicitor.ForEach(delegate (SolicitorsModel sm)
            {
                if(String.Equals(sm.firstName, firstName) && String.Equals(sm.lastName, secondName))
                {
                    workingSolicitor = sm;
                    hourlyRate = workingSolicitor.hourlyRates[0];
                    found = true;
                }
                Console.WriteLine(firstName + secondName);
                Console.WriteLine(sm.firstName + sm.lastName);
            });
            if(found == false) // For debugging purposes
            {
                MessageBox.Show("Could not find chosen solicitor" + " " + firstName + secondName);
                return;
            }
            if(hourlyRate > 0 && hoursInput.Value > 0 && percentageClaimedTextBox.Value > 0)
            {
                double timeSpent = Decimal.ToDouble(hoursInput.Value);
                double perc = Decimal.ToDouble(percentageClaimedTextBox.Value);
                perc = perc / 100.00;
                totalInput.Value = Convert.ToDecimal(hourlyRate * timeSpent * perc);
                gstInput.Value = totalInput.Value / 10;
            }
        }

        /// <summary>
        /// Automatically update the % Claimed in the description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void percentageClaimedTextBox_ValueChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(descriptionTextBox.Text) && !turnOffHoursCheckBox.Checked && percentageClaimedTextBox.Value < 100)
            {
                try
                {
                    //work on automatically updating the % time claimed.
                    updateDescription();

                    string[] descriptions = descriptionTextBox.Text.Split('–'); //Split the entire description

                    //Get the percentage of the entry that is claimed.
                    string getPercent = descriptions[descriptions.Length - 1];
                    if (getPercent.Contains('%'))
                    {
                        string[] getPerc = getPercent.Split('%');
                        string per = getPerc[0];
                        string[] percentages = per.Split('(');
                        per = percentages[percentages.Length - 1];

                        // Get the new percentage and add it to the existing description.
                        try
                        {
                            double percentageClaimed = Decimal.ToDouble(percentageClaimedTextBox.Value);
                            per = percentageClaimed.ToString();
                            //MessageBox.Show(per);

                            percentages[percentages.Length - 1] = per;
                            per = String.Join("(", percentages);
                            //MessageBox.Show(per);

                            getPerc[0] = per;
                            getPercent = String.Join("%", getPerc);
                            //MessageBox.Show(getPercent);

                            descriptions[descriptions.Length - 1] = getPercent;

                            string toEnter = String.Join("–", descriptions);

                            descriptionTextBox.Text = toEnter;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    } else
                    {
                        string desc = descriptionTextBox.Text;
                        string extra = " (" + percentageClaimedTextBox.Value + "% claimed)";

                        descriptionTextBox.Text = desc + extra;
                    }



                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            } else if(percentageClaimedTextBox.Value == 100)
            {
                try
                {
                    string[] hoursPerc = descriptionTextBox.Text.Split('–');
                    string description = hoursPerc[hoursPerc.Length - 1]; // Get only the entries at the end of the description.

                    string[] desc = description.Split('(');

                    if(desc.Length > 1)
                    {
                        desc[desc.Length - 1] = "";
                    }
                    
                    description = String.Join("(", desc);

                    // If there is a '(' in the final two characters, then remove it.
                    string hold = description.Substring(description.Length - 2);
                    if (hold.Contains('('))
                    {
                        description = description.Substring(0, description.Length - 2);
                    }

                    hoursPerc[hoursPerc.Length - 1] = description;

                    description = String.Join("–",hoursPerc);

                    descriptionTextBox.Text = description;

                    Console.WriteLine("Nothing should show in the description");
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            // Automatically change the total value and GST.
            if (hourlyRate > 0 && hoursInput.Value > 0 && percentageClaimedTextBox.Value > 0)
            {
                double timeSpent = Decimal.ToDouble(hoursInput.Value);
                double perc = Decimal.ToDouble(percentageClaimedTextBox.Value);
                perc = perc / 100.00;
                totalInput.Value = Convert.ToDecimal(hourlyRate * timeSpent * perc);
                gstInput.Value = totalInput.Value / 10;
            }
        }

        private void NewEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                BillForm bf = new BillForm();
                bf.setBillModel(em);
                bf.Show();
            }
            
        }
    }
}
