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
            displayTypes();
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

        /// <summary>
        /// Deletes a particular type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selected = DisbursementTypesBox.SelectedIndex;

            if(selected < 0) // User has to select a type first.
            {
                MessageBox.Show("Please choose an entry if you would like to delete something.");
                return;
            }

            if(selected == 0) // Cannot delete type unknown.
            {
                return;
            } else            // If the user has selected a valid type, they can delete it, after confirmation.
            {
                if (MessageBox.Show("Are you sure you want to delete this type?", "Delete Window Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                
                if(em.usedDisbursementTypes[selected].numDisbursements > 0)
                {
                    int i = -1;
                    List<int> indexes = new List<int>();

                    // change all of the relevant entries to having 'unknown' type.
                    foreach (DisbursementsModel dm in em.disbursements)
                    {
                        i++;
                        string type = em.usedDisbursementTypes[selected].type;

                        if (dm.typeOfDisbursement.type.Equals(type))
                        {
                            dm.typeOfDisbursement = em.usedDisbursementTypes[0];
                            em.usedDisbursementTypes[0].numDisbursements++;
                            indexes.Add(i);
                        }
                    }

                    // Insert the unknown disbursements back into the start of the unknown section of the list.
                    foreach (int j in indexes)
                    {
                        DisbursementsModel dis = em.disbursements[j];
                        em.disbursements.RemoveAt(j);
                        em.disbursements.Insert(0, dis);
                    }

                    try
                    {
                        // Sort the new set of unknowns.
                        sortUnknown();
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    
                }

                //Try to delete the entry.
                try
                {
                    em.usedDisbursementTypes.RemoveAt(selected);
                } catch (System.ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine("Argument is out of range.\n\n" + aore);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                
            }
            displayTypes(); // Display the new list.
        }

        /// <summary>
        /// Sorts the unknown portion of the disbursements list.
        /// </summary>
        public void sortUnknown()
        {
            int i = 1;
            // For each of the disbursements.
            while (i < em.disbursements.Count && em.disbursements[i].typeOfDisbursement.type.Equals("Unknown"))
            {
                int j = i - 1;
                // find where it fits relative to all of the entries before it.
                while(j >= 0 && DateTime.Compare(em.disbursements[j].date,em.disbursements[i].date) > 0)
                {
                    j--;
                }
                DisbursementsModel hold = em.disbursements[i];

                em.disbursements.RemoveAt(i);
                em.disbursements.Insert(j+1, hold);
                i++; // Move onto next entry.
            }
        }

        /// <summary>
        /// Displays all of the types in the types box.
        /// </summary>
        private void displayTypes()
        {
            DisbursementTypesBox.Items.Clear(); // First clear the display box.
            if (em != null)
            {
                disTypeModel = em.usedDisbursementTypes;

                //Loop through the list of disbursement types (be it used or unused)
                foreach (DisbursementTypeModel dtm in disTypeModel)
                {
                    if (!String.IsNullOrEmpty(dtm.type))
                    {
                        DisbursementTypesBox.Items.Add(dtm.type);
                    }
                }
            }
            else
            {
                DisbursementTypesBox.Items.Add("No disbursement types");
            }
        }
    }
}
