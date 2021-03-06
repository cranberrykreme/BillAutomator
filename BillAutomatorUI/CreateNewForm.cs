using System;
using System.IO;
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
    public partial class CreateNewForm : Form
    {
        /// <summary>
        /// Accessed from the dashboard page, this will get the user to
        /// choose the location to create a new file, as well as getting them
        /// to determine the name/number and type of bill to create.
        /// It will also allow users to return to the dashboard form.
        /// </summary>

        public string location;
        private bool openingNew = false; //Is a new form being opened upon the close of this form?
        public CreateNewForm()
        {
            InitializeComponent();
        }

        public void runStartup()
        {
            typeBillDropDown.Items.Add("Solicitor/Client");
            typeBillDropDown.Items.Add("Party/Party");
            hasDisbursementsCheckBox.Checked = true;
        }

        private void fileLocationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.Description = "Choose clients file to save in";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show(fbd.SelectedPath);
                location = fbd.SelectedPath;
                fileLocationTextBox.Text = location;
            }
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = clientNameTextBox.Text;
                string number = clientNumberTextBox.Text;
                int typeIndex = typeBillDropDown.SelectedIndex;
                string type;
                Document doc;

                //Get current date information.
                string days = DateTime.Now.ToString("dd");
                string months = DateTime.Now.ToString("MM");
                string year = DateTime.Now.ToString("yyyy");

                //If no location selected, return and prompt user.
                if (String.IsNullOrEmpty(location))
                {
                    MessageBox.Show("Please choose a location to save the file.");
                    return;
                }

                //If no name is entered, return and prompt user.
                if (String.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter the clients name.");
                    return;
                }

                //If no number is entered, return and prompt user.
                if (String.IsNullOrEmpty(number))
                {
                    MessageBox.Show("Please enter the clients number.");
                    return;
                }

                //If no type of bill is selected, return and prompt the user.
                if (typeIndex < 0)
                {
                    MessageBox.Show("Please select a type of bill to create.");
                    return;
                } else
                {
                    type = typeBillDropDown.Text;
                    //MessageBox.Show(type);
                    Console.WriteLine(type);
                }

                //Get type of bill
                if (type.Equals("Party/Party"))
                {

                    try
                    {
                        Application ap = new Application();
                        try
                        {
                            doc = ap.Documents.Open(@"M:\Templates\Blue Ribbon Documents\" + year + " MM DD - MATTER NUMBER - MATTER NAME - party party draft bill of costs.docx");
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            try
                            {
                                doc = ap.Documents.Open(@"Z:\Templates\Blue Ribbon Documents\" + year + " MM DD - MATTER NUMBER - MATTER NAME - party party draft bill of costs.docx");
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show("Sorry there is an issue with retrieving the templates from the miscellaneous drives, you will have to manually create and save in the correct spot and then open the existing file.");
                                Console.WriteLine(exception);
                                return;
                            }
                        }

                        //ap.Visible = true;

                        string loc = @location + @"\" + year + " " + months + " " + days + " - " + number + " - " + name + " - " + "party party draft bill of costs";
                        //MessageBox.Show(loc);

                        if (File.Exists(loc + ".docx"))
                        {
                            if (MessageBox.Show("There already exists a party/party bill with the date: " +
                                    days + " " + months + " " + year + ", with the name: " +
                                    name + " and the number: " + number + ". Continuing will overwrite the current file." +
                                    "\n\n" + "Would you Like to continue?",
                                    "Open File Confirmation",
                                MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                doc.Close();
                                return;
                            }
                        }

                        doc.SaveAs2(loc);

                        //Open new document to edit in the bills form.
                        ap.Visible = true;

                        BillForm billForm = new BillForm();
                        billForm.runStartup(doc, loc + ".docx", 2, 3, 4, hasDisbursementsCheckBox.Checked);
                        billForm.Show();
                        openingNew = true;
                        this.Close();
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Console.WriteLine(ex);
                    }
                } else if (type.Equals("Solicitor/Client"))
                {
                    try
                    {
                        Application ap = new Application();
                        try
                        {
                            doc = ap.Documents.Open(@"M:\Templates\Blue Ribbon Documents\" + year + " MM DD - MATTER NUMBER - MATTER NAME - solicitor client draft bill of costs.docx");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            try
                            {
                                doc = ap.Documents.Open(@"Z:\Templates\Blue Ribbon Documents\" + year + " MM DD - MATTER NUMBER - MATTER NAME - solicitor client draft bill of costs.docx");
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show("Sorry there is an issue with retrieving the templates from the miscellaneous drives, you will have to manually create and save in the correct spot and then open the existing file.");
                                Console.WriteLine(exception);
                                return;
                            }
                        }

                        string loc = @location + @"\" + year + " " + months + " " + days + " - " + number + " - " + name + " - " + "solicitor client draft bill of costs";
                        //MessageBox.Show(loc);
                        if (File.Exists(loc + ".docx"))
                        {
                            if (MessageBox.Show("There already exists a solicitor/client bill with the date: " +
                                    days + " " + months + " " + year + ", with the name: " +
                                    name + " and the number: " + number + ". Continuing will overwrite the current file." +
                                    "\n\n" + "Would you Like to continue?",
                                    "Open File Confirmation",
                                MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                doc.Close();
                                return;
                            }
                        }
                        doc.SaveAs2(loc);

                        //Open new document to edit in the bills form.
                        ap.Visible = true;

                        BillForm billForm = new BillForm();
                        billForm.runStartup(doc, loc + ".docx", 1, 2, 3, hasDisbursementsCheckBox.Checked);
                        billForm.Show();
                        openingNew = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Error with type of bill selected.");
                    return;
                }

                
                

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void CreateNewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!openingNew)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit Window Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
