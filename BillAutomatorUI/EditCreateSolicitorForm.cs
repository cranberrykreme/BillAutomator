using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ALL DONE FOR NOW.
namespace BillAutomatorUI
{
    /// <summary>
    /// Form that allows the user to create and edit a
    /// solicitor's profile. Takes name, hourly rate and other
    /// information to create or edit the profile.
    /// </summary>
    public partial class EditCreateSolicitorForm : Form
    {
        BillModel em;
        SolicitorsModel solicitor;
        private bool editing = false;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?

        public EditCreateSolicitorForm()
        {
            InitializeComponent();
        }

        // Set the bill model to be the most current version.
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
            hourlyRatesBox.Items.Add("This section has no functionality");
        }

        // When a solicitor is given to edit.
        public void editSol(SolicitorsModel aSolicitor)
        {
            editing = true;
            solicitor = aSolicitor;
            firstNameTextBox.Text = solicitor.firstName;
            lastNameTextBox.Text = solicitor.lastName;
            initialsTextBox.Text = solicitor.initials;
            doaTextBox.Text = solicitor.dateOfAdmission;
            try
            {
                hourlyRateInput.Value = Convert.ToDecimal(solicitor.hourlyRates[0]);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Cannot convert from double to decimal");
            }
            noChangeInRateCheckBox.Checked = true;
        }

        // To move back to the Solicitor Management Form.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            leaveScreen();
        }

        private void leaveScreen()
        {
            SolicitorManagementForm smf = new SolicitorManagementForm();
            smf.setBillModel(em);
            smf.runSetUp();
            smf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// This method is when the user has inputted all of the relevant information
        /// and would like to create or edit the solicitors profile for it to be added to
        /// the list of profiles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //solicitor.changed = true; //The solicitor has now been edited.

            if (editing == true)
            { //To run if a profile is being edited
                double prevRate = solicitor.hourlyRates[0];
                //Find the correct index of the solicitor we are looking for.
                int index = em.solicitor.FindIndex(s => s == solicitor);

                //Add all of the correct values to our solicitor model.
                if(!String.IsNullOrEmpty(firstNameTextBox.Text))
                {
                    solicitor.firstName = firstNameTextBox.Text;
                }
                if(!String.IsNullOrEmpty(lastNameTextBox.Text))
                {
                    solicitor.lastName = lastNameTextBox.Text;
                }
                if (!String.IsNullOrEmpty(initialsTextBox.Text))
                {
                    solicitor.initials = initialsTextBox.Text;
                }

                solicitor.dateOfAdmission = doaTextBox.Text; //Set the doa to be empty string if textbox is empty
                

                if (hourlyRateInput.Value != 0)
                {
                    solicitor.hourlyRates[0] = Decimal.ToDouble(hourlyRateInput.Value);
                }
                
                //If nothing has been selected, print out an error message.
                if(index != -1)
                {
                    em.solicitor[index] = solicitor;
                    leaveScreen();
                } else
                {
                    MessageBox.Show("Cannot find solicitor to replace");
                }
                double newRate = em.solicitor[index].hourlyRates[0];

                //Change the relevant entries if the hourly rate has been changed
                if (prevRate != newRate)
                {
                    em.entries.ForEach(delegate (EntriesModel entry)
                    {
                        entry.amount = entry.hours * entry.solicitor.hourlyRates[0] * (entry.percentage / 100.00);
                        entry.GST = entry.amount / 10;
                    });
                }
            } else
            {//To be run if a new profile is being created.
                solicitor = new SolicitorsModel();
                bool info = true; //to catch if any information is missing

                if (!String.IsNullOrEmpty(firstNameTextBox.Text))
                {
                    solicitor.firstName = firstNameTextBox.Text;
                    
                }
                else
                {
                    info = false;
                }

                if (!String.IsNullOrEmpty(lastNameTextBox.Text))
                {
                    solicitor.lastName = lastNameTextBox.Text;
                } else
                {
                    info = false;
                }

                if (!String.IsNullOrEmpty(initialsTextBox.Text))
                {
                    solicitor.initials = initialsTextBox.Text;
                } else
                {
                    info = false;
                }

                solicitor.dateOfAdmission = doaTextBox.Text; //Set the doa to be empty string if textbox is empty

                if (hourlyRateInput.Value != 0)
                {
                    double hourly = Convert.ToDouble(hourlyRateInput.Value);

                    List<double> rates = new List<double>();
                    rates.Add(hourly);
                    solicitor.hourlyRates = rates;
                } else
                {
                    info = false;
                }

                // If the correct information is not entered after the user tries to create the profile
                if (info)
                {
                    em.solicitor.Add(solicitor);
                    leaveScreen();
                } else
                {
                    MessageBox.Show("Please enter the correct information first; being" +
                        " the first name, last name, initials and hourly rate");
                }
                
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Find the correct index of the solicitor we are looking for.
            int index = em.solicitor.FindIndex(s => s == solicitor);

            //The user will be stopped from deleting the default lawyer.
            if (index == 0)
            {
                MessageBox.Show("You cannot delete the default solicitor.");
                return;
            }

            //Confirmation box for deleting a lawyer.
            if (MessageBox.Show("Are you sure you want to delete this Lawyer? All their entries will be updated.", "Delete Lawyer Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            

            //Remove from list
            em.solicitor.RemoveAt(index);

            for(int i = index; i < em.solicitor.Count; i++)
            {
                em.solicitor[i].changed = true;
            }

            //Remove the solicitor from all of the relevant entries.
            foreach(EntriesModel entry in em.entries)
            {
                string entryName = entry.solicitor.initials;
                string solName = solicitor.initials;

                if(String.Equals(solName, entryName))
                {
                    entry.solicitor = em.solicitor[0];
                }
            }

            //Leave form
            leaveScreen();
        }

        /// <summary>
        /// Only allow alphabetical characters to be inputted into the initial text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initialsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(initialsTextBox.Text, "^[a-zA-z]"))
            {
                
                if(initialsTextBox.Text.Length > 0)
                {
                    MessageBox.Show("This textbox accepts only alphabetical characters");
                    initialsTextBox.Clear();
                }
                
            }
        }

        /// <summary>
        /// Only allow alphabetical characters to be inputted into the first name text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(firstNameTextBox.Text, "^[a-zA-z]"))
            {
                if(firstNameTextBox.Text.Length > 0)
                {
                    MessageBox.Show("This textbox accepts only alphabetical characters");
                    firstNameTextBox.Clear();
                }
               
            }
        }

        /// <summary>
        /// Only allow alphabetical characters to be inputted into the last name text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(lastNameTextBox.Text, "^[a-zA-z]"))
            {
                if(lastNameTextBox.Text.Length > 0)
                {
                    MessageBox.Show("This textbox accepts only alphabetical characters");
                    lastNameTextBox.Clear();
                }
                
            }
        }

        private void EditCreateSolicitorForm_FormClosing(object sender, FormClosingEventArgs e)
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
