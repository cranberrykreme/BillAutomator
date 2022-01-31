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
    /// This form allows the user to enter disbursements, of
    /// different types. It will also link to the counsel's 
    /// management form, allowing users to navigate.
    /// </summary>
    public partial class DisbursementForm : Form
    {
        private BillModel em;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?
        private bool editing = false; //Is the current disbursement a new entry or editing of an old one?
        private int index; //The index of the disbursement in the list.
        private DisbursementsModel dm; //The disbursements model to edit/create.

        public DisbursementForm()
        {
            InitializeComponent();
        }

        // Set up the new entry form, fill out the drop-down with disbursement types
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
            em.usedDisbursementTypes.ForEach(delegate (DisbursementTypeModel dtm)
            {
                typeDropDown.Items.Add(dtm.type);
            });
        }

        /// <summary>
        /// Set all of the relevant information on the form for editing an existing
        /// disbursement entry.
        /// </summary>
        /// <param name="aIndex"></param>
        public void runEditingSetup(int aIndex)
        {
            index = aIndex;
            dm = em.disbursements[index];

            //Set the date box
            dateTimeBox.Value = dm.date;

            //Set the type box
            string disType = dm.typeOfDisbursement.type;
            int i = -1;
            foreach(string type in typeDropDown.Items)
            {
                i++;
                if (type.Equals(disType))
                {
                    typeDropDown.SelectedIndex = i;
                    break;
                }
            }

            //Set the description
            descriptionTextBox.Text = dm.description;

            //Set the amount
            decimal input = Convert.ToDecimal(dm.amount);
            totalInput.Value = input;
        }

        private void DisbursementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                BillForm bf = new BillForm();
                bf.setBillModel(em);
                bf.Show();
            }
        }

        private void cancelEntryButton_Click(object sender, EventArgs e)
        {
            leaveScreen();
        }

        private void leaveScreen()
        {
            BillForm smf = new BillForm();
            smf.setBillModel(em);
            smf.Show();
            openingNew = true;
            this.Close();
        }
    }
}
