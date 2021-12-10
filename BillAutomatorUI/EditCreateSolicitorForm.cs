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
    /// Form that allows the user to create and edit a
    /// solicitor's profile. Takes name, hourly rate and other
    /// information to create or edit the profile.
    /// </summary>
    public partial class EditCreateSolicitorForm : Form
    {
        BillModel em;
        SolicitorsModel solicitor;
        private bool editing = false;
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
            SolicitorManagementForm smf = new SolicitorManagementForm();
            smf.setBillModel(em);
            smf.runSetUp();
            smf.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(editing == true)
            {
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
                if(hourlyRateInput.Value != 0)
                {
                    solicitor.hourlyRates[0] = Decimal.ToDouble(hourlyRateInput.Value);
                }
                
                

                if(index != -1)
                {
                    em.solicitor[index] = solicitor;
                } else
                {
                    MessageBox.Show("Cannot find solicitor to replace");
                }
                
            } else
            {
                solicitor = new SolicitorsModel();
                

            }
        }
    }
}
