using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//DONE FOR NOW.
namespace BillAutomatorUI
{
    /// <summary>
    /// Simple form that allows the user to view all of the 
    /// currently made solicitors profiles and links to the
    /// ability to edit them or to create a new one.
    /// </summary>
    public partial class SolicitorManagementForm : Form
    {
        BillModel em;
        List<SolicitorsModel> sm;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?

        public SolicitorManagementForm()
        {
            InitializeComponent();
        }

        public void runSetUp()
        {
            if(em != null)
            {
                sm = em.solicitor;
                sm.ForEach(delegate (SolicitorsModel sol)
                {
                    if (!String.IsNullOrEmpty(sol.firstName))
                    {
                        solicitorsBox.Items.Add(sol.firstName + " " + sol.lastName + " - " +
                        sol.initials + " - $" + sol.hourlyRates[0]);
                    }
                    else
                    {
                        solicitorsBox.Items.Add(sol.lastName + " - " +
                        sol.initials + " - $" + sol.hourlyRates[0]);
                    }
                    
                });
            } else
            {
                solicitorsBox.Items.Add("No current solicitors");
            }
        }

        // Set the bill model to be the most current version.
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
        }

        // Return to bill form.
        private void returnButton_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            openingNew = true;
            this.Close();
        }

        private void addSolicitorButton_Click(object sender, EventArgs e)
        {
            EditCreateSolicitorForm newSol = new EditCreateSolicitorForm();
            newSol.setBillModel(em);
            newSol.Show();
            openingNew = true;
            this.Close();
        }

        // When a certain solicitor has been selected
        private void editSolicitorButton_Click(object sender, EventArgs e)
        {
            EditCreateSolicitorForm editSol = new EditCreateSolicitorForm();
            SolicitorsModel solicitorToEdit = new SolicitorsModel();
            bool foundSol = false;

            if (solicitorsBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a solicitor to edit");
                return;
            }
            // Get the relevant initials
            string chosenSol = solicitorsBox.SelectedItem.ToString();
            string[] solParameters = chosenSol.Split('-');
            string chosenSolInitials = solParameters[1];
            chosenSolInitials = chosenSolInitials.Replace(" ", ""); //remove whitespace

            sm.ForEach(delegate (SolicitorsModel solToEdit)
            {
                // If the initials from the entry are available in the list of solicitors.
                if(String.Equals(solToEdit.initials, chosenSolInitials))
                {
                    solicitorToEdit = solToEdit;
                    foundSol = true;
                }
            });
            if(!foundSol)
            {
                MessageBox.Show("No solicitor available in the list of entries.");
            } else
            {
                editSol.editSol(solicitorToEdit);
            }

            //Normal setup.
            editSol.setBillModel(em);
            editSol.Show();
            openingNew = true;
            this.Close();
        }

        private void SolicitorManagementForm_FormClosing(object sender, FormClosingEventArgs e)
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
