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
        public NewEntryForm()
        {
            InitializeComponent();
        }

        public void setBillModel(BillModel aEm)
        {
            em = aEm;
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
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Please Fill in all of the relevant sections before creating entry");
            }


            //Send user back to the bill form.
            BillForm bf = new BillForm();
            bf.setBillModel(em);
            bf.Show();
            this.Close();
        }
    }
}
