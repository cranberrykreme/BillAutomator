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
    /// Simple form that takes 3 pieces of information and
    /// creates or edits a counsel profile.
    /// </summary>
    public partial class EditCreateDisbursementTypeForm : Form
    {
        BillModel em;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?
        private bool editing = false; //Are we editing an existing entry or making a new one?
        private DisbursementTypeModel dtm; //stores the disbursement type model fed in to edit.
        private int index; //stores the index of the type in the entries list.

        public EditCreateDisbursementTypeForm()
        {
            InitializeComponent();
        }

        // Set the bill model to be the most current version.
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
        }

        /// <summary>
        /// Sets the type input box and tells us which disbursement type
        /// we are editing.
        /// </summary>
        /// <param name="aType"></param>
        public void setExistingType(int aIndex)
        {
            editing = true;
            index = aIndex;
            dtm = em.usedDisbursementTypes[index];

            typeTextBox.Text = dtm.type;
        }

        /// <summary>
        /// When the user wants to leave the current form without making any changes to the disbursement's list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DisbursementTypeManagementForm dtmf = new DisbursementTypeManagementForm();
            dtmf.setBillModel(em);
            dtmf.runSetUp();
            dtmf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// Handles when the form is closed by an unintended method (i.e. the red cross is pressed)
        /// the user is automatically sent back to the bill form, with their information in tact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCreateDisbursementTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                BillForm bf = new BillForm();
                bf.setBillModel(em);
                bf.Show();
            }
        }

        /// <summary>
        /// Handles the process of adding/editing a type to the disbursements type list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string type = typeTextBox.Text;
                if (string.IsNullOrEmpty(type))
                {
                    MessageBox.Show("Please fill in the type text input box before saving.");
                    return;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            if (editing)
            {
                em.usedDisbursementTypes[index].type = typeTextBox.Text;
            } else
            {
                DisbursementTypeModel disTypeModel = new DisbursementTypeModel();
                disTypeModel.numDisbursements = 0;
                disTypeModel.type = typeTextBox.Text;
                em.usedDisbursementTypes.Add(disTypeModel);
            }

            //Close this form and open the management form.
            DisbursementTypeManagementForm dtmf = new DisbursementTypeManagementForm();
            dtmf.setBillModel(em);
            dtmf.runSetUp();
            dtmf.Show();
            openingNew = true;
            this.Close();
        }
    }
}
