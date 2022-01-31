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
    /// This form allows the user to input new disbursements
    /// that are directley allocated to a particular counsel
    /// that they have already entered.
    /// </summary>
    public partial class DisbursementTypeManagementForm : Form
    {
        BillModel em;
        List<DisbursementTypeModel> disTypeModel;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?

        public DisbursementTypeManagementForm()
        {
            InitializeComponent();
        }

        // Set the bill model to be the most current version.
        public void setBillModel(BillModel aEm)
        {
            em = aEm;
        }

        // Set up the display box to show all the used and unused disbursements.
        public void runSetUp()
        {
            if(em != null)
            {
                disTypeModel = em.usedDisbursementTypes;
                
                //Loop through the list of disbursement types (be it used or unused)
                foreach(DisbursementTypeModel dtm in disTypeModel)
                {
                    if (!String.IsNullOrEmpty(dtm.type))
                    {
                        DisbursementTypesBox.Items.Add(dtm.type);
                    }
                }
            } else
            {
                DisbursementTypesBox.Items.Add("No disbursement types");
            }
        }

        /// <summary>
        /// Handles returning back to the bill form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnButton_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// Handles when the form is closed by an unintended method (i.e. the red cross is pressed)
        /// the user is automatically sent back to the bill form, with their information in tact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisbursementTypeManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                BillForm bf = new BillForm();
                bf.setBillModel(em);
                bf.Show();
            }
        }

        /// <summary>
        /// Handles when the user wants to add a new type of disbursement to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTypeButton_Click(object sender, EventArgs e)
        {
            EditCreateDisbursementTypeForm ecdtf = new EditCreateDisbursementTypeForm();
            ecdtf.setBillModel(em);
            ecdtf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// Takes the selected disbursement type and sets up the edit disbursement type form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editTypeButton_Click(object sender, EventArgs e)
        {
            if(DisbursementTypesBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a type to edit.");
                return;
            }

            string desc = DisbursementTypesBox.SelectedItem.ToString();
            int index = findDisIndex(desc);

            if(index < 0)
            {
                MessageBox.Show("Cannot find selected disbursement type.");
                return;
            }

            EditCreateDisbursementTypeForm ecdtf = new EditCreateDisbursementTypeForm();
            ecdtf.setBillModel(em);
            ecdtf.setExistingType(index);
            ecdtf.Show();
            openingNew = true;
            this.Close();
        }

        /// <summary>
        /// Returns the index of the disbursement in the list of disbursmenents.
        /// </summary>
        /// <returns></returns>
        private int findDisIndex(string type)
        {
            int index = -1;
            foreach(DisbursementTypeModel dtm in disTypeModel)
            {
                index++;
                if (dtm.type.Equals(type))
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
