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
        }

        private void cancelEntryButton_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            this.Close();
        }

        // TODO - Finish feeding the information into the entry and then add the entry to
        // the overal bill model.
        private void createEntryButton_Click(object sender, EventArgs e)
        {
            EntriesModel ent = new EntriesModel();

            //Find all of the relevant peices of data.
            try
            {
                try //Fill in the correct date for an entry.
                {
                    DateTime dt = dateTimeBox.Value;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Please Fill in all of the relevant sections before creating entry");
            }

            bool foundDate = false;
            bool afterDate = true;
            // Get the correct date and location to add the new entry to in the list.
            em.entries.ForEach(delegate (EntriesModel entry)
            {
                int diff = DateTime.Compare(entry.date, ent.date);
                if(diff == 0)
                {
                    foundDate = true;
                } else if(diff > 0) // if new entry is earlier than this date it will be > 0
                {

                }
            });

            //Send user back to the bill form.
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            this.Close();
        }

        /// <summary>
        /// When a user inputs the hours into the entry form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hoursInput_valueChanged(object sender, EventArgs e)
        {
            if (hourlyRate > 0 && hoursInput.Value > 0)
            {
                double timeSpent = Decimal.ToDouble(hoursInput.Value);
                totalInput.Value = Convert.ToDecimal(hourlyRate * timeSpent);
                gstInput.Value = totalInput.Value / 10;
            }
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
                firstName = firstName + names[loc];
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
            if(hourlyRate > 0 && hoursInput.Value > 0)
            {
                double timeSpent = Decimal.ToDouble(hoursInput.Value);
                totalInput.Value = Convert.ToDecimal(hourlyRate * timeSpent);
                gstInput.Value = totalInput.Value / 10;
            }
        }
    }
}
