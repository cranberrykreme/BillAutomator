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
        private DisbursementsModel disModel; //The disbursements model to edit/create.

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
            disModel = em.disbursements[index]; // get the disbursement
            editing = true;

            //Set the date box
            dateTimeBox.Value = disModel.date;

            //Set the type box
            string disType = disModel.typeOfDisbursement.type;
            int i = -1;
            foreach(string type in typeDropDown.Items)
            {
                i++;
                if (type.Equals(disType))
                {
                    typeDropDown.SelectedIndex = i;
                    em.usedDisbursementTypes[i].numDisbursements--; // Reduce the number of disbursements in this type by 1.
                    break;
                }
            }

            //Set the description
            descriptionTextBox.Text = disModel.description;

            //Set the amount
            decimal input = Convert.ToDecimal(disModel.amount);
            totalInput.Value = input;

            try
            {
                //Set the gst and charge checkboxes.
                noChargeCheckBox.Checked = disModel.noCharge;
                gstCheckBox.Checked = disModel.noGST;
                

                if (disModel.noCharge)
                {
                    gstCheckBox.Checked = true;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// If the form is closing, if it is closing in a way intended then this method won't do anything,
        /// however if something else has happened, the bill form shall be re-opened, with all of the
        /// relevant information in the em list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            smf.showDis();
            openingNew = true;
            this.Close();
        }

        private void createEntryButton_Click(object sender, EventArgs e)
        {
            DateTime date;
            string desc;
            double value;
            DisbursementTypeModel dtm;
            updateDescription();

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
            dm.noGST = gstCheckBox.Checked;
            dm.noCharge = noChargeCheckBox.Checked;

            if (editing == true) // If the current entry already exists and is just being edited.
            {
                int diff = DateTime.Compare(disModel.date, dm.date);
                if (disModel.typeOfDisbursement.type.Equals(dm.typeOfDisbursement.type) && diff == 0) //If the disType and date are the same as before.
                {
                    em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                    em.disbursements[index] = dm;
                } else if (dm.typeOfDisbursement.numDisbursements < 1 && !disModel.typeOfDisbursement.type.Equals(dm.typeOfDisbursement.type)) //If this is the first of that disbursment type, and the type is being changed.
                {
                    em.disbursements.RemoveAt(index);   // remove the relevant disbursement, that has been edited.
                    if (dm.typeOfDisbursement.type.Equals("Unknown"))
                    {
                        em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                        em.disbursements.Insert(0, dm);
                    }
                    else
                    {
                        em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                        em.disbursements.Add(dm);
                    }
                } else //If either the date or the disType is different, and this is not the first disbursement of that type.
                {
                    int disIndex = locateEntry(dm);

                    if (disIndex < 0)
                    {
                        MessageBox.Show("Cannot find location to enter disbursement.");
                        return;
                    }

                    em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                    em.disbursements.Insert(disIndex, dm);

                    if(disIndex < index) //If the new entry has been inserted before the old entry.
                    {
                        index++;
                    }

                    em.disbursements.RemoveAt(index);   // remove the relevant disbursement, that has already been edited.
                }

            } else // If this is a new entry
            {

                if(dm.typeOfDisbursement.numDisbursements < 1)
                {
                    if (dm.typeOfDisbursement.type.Equals("Unknown"))
                    {
                        em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                        em.disbursements.Insert(0,dm);
                    } else
                    {
                        em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                        em.disbursements.Add(dm);
                    }
                    
                }
                else
                {
                    int disIndex = locateEntry(dm);

                    if(disIndex < 0)
                    {
                        MessageBox.Show("Cannot find location to enter disbursement.");
                        return;
                    }

                    em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                    em.disbursements.Insert(disIndex, dm);

                }

            }

            leaveScreen();
        }

        /// <summary>
        /// Finds the location that the disbursement should be entered into in the 
        /// disbursements list.
        /// </summary>
        /// <param name="dm"></param>
        private int locateEntry(DisbursementsModel dm)
        {
            int ans = -1;

            int typeStartIndex = -1;
            int typeEndIndex = -1;
            bool foundStart = false;
            bool foundEnd = false;
            int index = -1;

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
                    typeEndIndex = index - 1;
                    break;
                }
            }

            if (!foundEnd) //If we have not found the end, set it to be the last entry in the list (as it is part of the last group of disbursements).
            {
                typeEndIndex = em.disbursements.Count - 1;
            }

            if (!foundStart)
            {
                //MessageBox.Show("Was not able to find disbursement type to enter");
                return -1;
            }
            else
            {
                DateTime hold = em.disbursements[typeEndIndex].date;
                DateTime date = dm.date;
                int holdResult = DateTime.Compare(date, hold);

                if (holdResult >= 0) //if the entry is the latest for that particular disbursement type.
                {
                    //em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                    //em.disbursements.Insert(typeEndIndex + 1, dm);

                    ans = typeEndIndex + 1;
                }
                else //if it is not the latest for that type of disbursement.
                {
                    for (int i = typeStartIndex; i <= typeEndIndex; i++)
                    {
                        DateTime dt = em.disbursements[i].date;

                        int result = DateTime.Compare(date, dt);
                        if (result < 0) //If the new entry is earlier than the one if it is being compared to.
                        {
                            //em.usedDisbursementTypes[typeDropDown.SelectedIndex].numDisbursements++;
                            //em.disbursements.Insert(i, dm);

                            ans = i;
                            break;
                        }
                    }
                }
            }

            return ans;
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

        /// <summary>
        /// Changes all short hyphens into long hypens in the description box (where gramatically correct).
        /// </summary>
        private void updateDescription()
        {
            descriptionTextBox.Text = descriptionTextBox.Text.Replace(" - ", " – ");
        }

        /// <summary>
        /// Allows the dateTime box to be set to a date by an incoming disbursement.
        /// </summary>
        /// <param name="date"></param>
        public void setDate(DateTime date)
        {
            try
            {
                dateTimeBox.Value = date;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// If the no gst checkbox is toggled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gstCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gstCheckBox.Checked) //If we are going from a no-GST situation to a GST situation.
            {
                gstInput.Value = 0;
                gstInput.ReadOnly = true;
                gstInput.Increment = 0;

                string[] descriptions = descriptionTextBox.Text.Split('(');
                string description = descriptions[descriptions.Length - 1];

                if(descriptions.Length < 2 && noChargeCheckBox.Checked) //If there is no charge, and there is currently no () in the description.
                {
                    description += " (No Charge)";
                    descriptionTextBox.Text = description;
                } else if (descriptions.Length < 2 && !noChargeCheckBox.Checked) //If there is not no charge and there is currently no () in the description.
                {
                    description += " (No GST)";
                    descriptionTextBox.Text = description;
                } else if(noChargeCheckBox.Checked) //Already a () in the description and there is no charge.
                {
                    if (description.Contains("No GST") || description.Contains("No Charge"))
                    {
                        description = "No Charge)";
                        descriptions[descriptions.Length - 1] = description;

                        string desc = String.Join("(", descriptions);
                        descriptionTextBox.Text = desc;
                    } else
                    {
                        //Re-join the list and add on the no charge
                        description = descriptionTextBox.Text;
                        descriptionTextBox.Text = description + " (No Charge)";
                    }
                } else //Already a () in the description and there is not no charge.
                {
                    if (description.Contains("No GST") || description.Contains("No Charge"))
                    {
                        description = "No GST)";
                        descriptions[descriptions.Length - 1] = description;

                        string desc = String.Join("(", descriptions);
                        descriptionTextBox.Text = desc;
                    }
                    else
                    {
                        //Re-join the list and add on the no GST
                        description = descriptionTextBox.Text;
                        descriptionTextBox.Text = description + " (No GST)";
                    }
                }
            } else // If we are going from a Gst situation to a no Gst situation.
            {
                gstInput.Value = totalInput.Value / 10;
                if (!noChargeCheckBox.Checked)
                {
                    gstInput.ReadOnly = false;
                    gstInput.Increment = Convert.ToDecimal(0.01);
                }

                string description = descriptionTextBox.Text;
                string[] descriptions = description.Split('(');

                string desc = descriptions[descriptions.Length - 1];

                if(desc.Contains("No Charge") && noChargeCheckBox.Checked) // If the description says no charge and the checkbox is also no charge, we have nothing to do.
                {
                    return;
                } else if((desc.Contains("No Charge") || desc.Contains("No GST")) && !noChargeCheckBox.Checked) // No charge, we have to delete the () from the description.
                {
                    descriptions[descriptions.Length - 1] = "";
                    description = String.Join("(", descriptions);
                    description = description.Substring(0, description.Length - 2);

                    descriptionTextBox.Text = description;
                }
            }
        }

        /// <summary>
        /// If the no charge check box is toggled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noChargeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noChargeCheckBox.Checked) // Going from Charge to no-Charge
            {
                totalInput.Value = 0;
                totalInput.ReadOnly = true;
                totalInput.Increment = 0;

                gstInput.ReadOnly = true;
                gstInput.Increment = 0;

                string description = descriptionTextBox.Text;
                string[] descriptions = description.Split('(');
                string desc = descriptions[descriptions.Length - 1];

                if(desc.Contains("No GST") || desc.Contains("No Charge")) //If a () currently exists in the description.
                {
                    desc = "No Charge)";
                    descriptions[descriptions.Length - 1] = desc;
                    description = String.Join("(", descriptions);
                    descriptionTextBox.Text = description;
                } else //if no () currently exists in the description.
                {
                    description = description + " (No Charge)";
                    descriptionTextBox.Text = description;
                }

            } else // Going from No-Charge to charge.
            {
                totalInput.ReadOnly = false;
                totalInput.Increment = Convert.ToDecimal(0.01);

                if (!gstCheckBox.Checked)
                {
                    gstInput.ReadOnly = false;
                    gstInput.Increment = Convert.ToDecimal(0.01);
                }

                string description = descriptionTextBox.Text;
                string[] descriptions = description.Split('(');
                string desc = descriptions[descriptions.Length - 1];

                if ((desc.Contains("No Charge") || desc.Contains("No GST")) && !gstCheckBox.Checked) // Remove the current ()
                {
                    desc = "";
                    descriptions[descriptions.Length - 1] = desc;
                    description = String.Join("(", descriptions);

                    description = description.Substring(0, description.Length - 2);
                    descriptionTextBox.Text = description;
                } else if (gstCheckBox.Checked) // change the description to be (No GST).
                {
                    desc = "No GST)";
                    descriptions[descriptions.Length - 1] = desc;
                    description = String.Join("(", descriptions);
                    descriptionTextBox.Text = description;
                }
            }
        }
    }
}
