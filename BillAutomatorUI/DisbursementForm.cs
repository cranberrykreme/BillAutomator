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
            editing = true;

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

        private void createEntryButton_Click(object sender, EventArgs e)
        {
            DateTime date;
            string desc;
            double value;
            DisbursementTypeModel dtm;

            //Try to retrieve the relevant information required to save the disbursement entry.
            try
            {
                date = dateTimeBox.Value;
                desc = descriptionTextBox.Text;
                value = Decimal.ToDouble(totalInput.Value);
            } catch (Exception ex)
            {
                MessageBox.Show("Error with inputed values.");
                Console.WriteLine(ex);
                return;
            }

            if (String.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Error with description value.");
                return;
            }

            if(typeDropDown.SelectedIndex > -1)
            {
                dtm = em.usedDisbursementTypes[typeDropDown.SelectedIndex];
            } else
            {
                MessageBox.Show("Please choose a type of disbursement from the drop down menu.");
                return;
            }

            DisbursementsModel dm = new DisbursementsModel();
            dm.date = date;
            dm.description = desc;
            dm.amount = value;
            dm.typeOfDisbursement = dtm;

            if (editing == true)
            {
                em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                em.disbursements[index] = dm;
            } else
            {
                int typeStartIndex = -1;
                int typeEndIndex = -1;
                bool foundStart = false;
                bool foundEnd = false;
                int index = -1;

                if(dm.typeOfDisbursement.numDisbursements < 1)
                {
                    em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                    em.disbursements.Add(dm);
                }
                else
                {
                    foreach (DisbursementsModel disModel in em.disbursements)
                    {
                        index++;
                        if (dm.typeOfDisbursement.type.Equals(disModel.typeOfDisbursement.type) && !foundStart) // if the types are equal and the first index has not yet been found
                        {
                            foundStart = true;
                            typeStartIndex = index;
                        }
                        else if (foundStart && !dm.typeOfDisbursement.type.Equals(disModel.typeOfDisbursement.type) && !foundEnd) // if the types are not equal, and the start has been found, and the end has not been found.
                        {
                            foundEnd = true;
                            typeEndIndex = index;
                            break;
                        }
                    }

                    if (!foundStart)
                    {
                        MessageBox.Show("Was not able to find disbursement type to enter");
                        return;
                    } else if (foundStart && !foundEnd)
                    {
                        em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                        em.disbursements.Add(dm);
                    } else
                    {
                        DateTime hold = em.disbursements[typeEndIndex].date;
                        int holdResult = DateTime.Compare(date, hold);

                        if (holdResult >= 0) //if the entry is the latest for that particular disbursement type.
                        {
                            em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                            em.disbursements.Insert(typeEndIndex + 1, dm);
                        } else //if it is not the latest for that type of disbursement.
                        {
                            for (int i = typeStartIndex; i <= typeEndIndex; i++)
                            {
                                DateTime dt = em.disbursements[i].date;

                                int result = DateTime.Compare(date, dt);
                                if (result < 0) //If the new entry is earlier than the one if it is being compared to.
                                {
                                    em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                                    em.disbursements.Insert(i, dm);
                                }
                            }
                        }
                    }

                }
                
            }

            leaveScreen();
        }

        /// <summary>
        /// When the total input value is changed, also change the gst value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void totalInput_ValueChanged(object sender, EventArgs e)
        {
            Decimal val = totalInput.Value;
            gstInput.Value = val / 10;
        }
    }
}
