using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace BillAutomatorUI
{
    public partial class TableInputForm : Form
    {
        private static Document doc; //will always have the same value
        private static string fileName; //will always have the same value.

        public TableInputForm()
        {
            InitializeComponent();

            billTypeDropDown.Items.Add("Solicitor/Client");
            billTypeDropDown.Items.Add("Party/Party");
        }

        /// <summary>
        /// Set up the table input form, inputting the relevant document and fileName as well as currently known tables.
        /// </summary>
        /// <param name="solTable"></param>
        /// <param name="entTable"></param>
        /// <param name="aDoc"></param>
        /// <param name="aFileName"></param>
        public void initialise(int solTable, int entTable, int disTable, Document aDoc, string aFileName)
        {
            solTableTextBox.Text = solTable.ToString();
            entriesTableTextBox.Text = entTable.ToString();
            disbursementsTableTextBox.Text = disTable.ToString();
            doc = aDoc;
            fileName = aFileName;
        }

        /// <summary>
        /// Automatically changes the default values in the solTextBox and entryTextBox to what is 'should' be for the
        /// particular bill that is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (billTypeDropDown.SelectedIndex == 1) //Party/party
            {
                solTableTextBox.Text = "2";
                entriesTableTextBox.Text = "3";
                disbursementsTableTextBox.Text = "4";
            }
            else // Solicitor/Client
            {
                solTableTextBox.Text = "1";
                entriesTableTextBox.Text = "2";
                disbursementsTableTextBox.Text = "3";
            }
        }

        /// <summary>
        /// Closes the current form and the word document (if able).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelTablesButton_Click(object sender, EventArgs e)
        {
            try
            {
                doc.Close();
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


            this.Close();
        }

        /// <summary>
        /// Push's the users choice of tables back to the bill form to run through the word document again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmTablesButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(solTableTextBox.Text) || String.IsNullOrEmpty(entriesTableTextBox.Text) || String.IsNullOrEmpty(disbursementsTableTextBox.Text))
            {
                MessageBox.Show("Please enter the correct numbers into the table input boxes.");
                return;
            }

            // Get the inputted table numbers.
            int solTable = Int32.Parse(solTableTextBox.Text);
            int entTable = Int32.Parse(entriesTableTextBox.Text);
            int disTable = Int32.Parse(disbursementsTableTextBox.Text);

            //Handle errors with the input tables.
            int tableCount = doc.Tables.Count;
            if(solTable > tableCount || entTable > tableCount || disTable > tableCount)
            {
                MessageBox.Show("You cannot access a table number higher than the total number of tables in the document, " +
                    "which is " + tableCount + " tables.");
                return;
            }
            if(solTable < 1 || entTable < 1 || disTable < 1)
            {
                MessageBox.Show("You cannot access any table before the first one. Please enter a value of 1 or greater in both boxes.");
                return;
            }

            try
            {
                BillForm billForm = new BillForm();
                billForm.runStartup(doc, fileName, solTable, entTable, disTable); // feed back into the bill form to read the tables.

                billForm.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                try
                {
                    doc.Close();
                    
                } catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }

            this.Close();
        }
    }
}
