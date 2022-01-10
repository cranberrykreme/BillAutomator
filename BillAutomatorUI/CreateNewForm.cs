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
    public partial class CreateNewForm : Form
    {
        /// <summary>
        /// Accessed from the dashboard page, this will get the user to
        /// choose the location to create a new file, as well as getting them
        /// to determine the name/number and type of bill to create.
        /// It will also allow users to return to the dashboard form.
        /// </summary>

        public string location;
        public CreateNewForm()
        {
            InitializeComponent();
        }

        public void runStartup()
        {
            typeBillDropDown.Items.Add("Solicitor/Client");
            typeBillDropDown.Items.Add("Party/Party");
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
                    MessageBox.Show(type);
                    Console.WriteLine(type);
                }

                //Get type of bill
                if (type.Equals("Party/Party"))
                {

                    try
                    {
                        Application ap = new Application();
                        doc = ap.Documents.Open(@"Z:\Templates\Blue Ribbon Documents\2021 MM DD - MATTER NUMBER - MATTER NAME - party party draft bill of costs.docx");

                        //ap.Visible = true;

                        string loc = @location + @"\" + year + " " + months + " " + days + " - " + number + " - " + name + " - " + "party party draft bill of costs";
                        MessageBox.Show(loc);
                        doc.SaveAs2(loc);

                        //Open new document to edit in the bills form.
                        ap.Visible = true;

                        BillForm billForm = new BillForm();
                        billForm.runStartup(doc, 2, 3);
                        billForm.Show();
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
                        doc = ap.Documents.Open(@"Z:\Templates\Blue Ribbon Documents\2021 MM DD - MATTER NUMBER - MATTER NAME - solicitor client draft bill of costs.docx");

                        string loc = @location + @"\" + year + " " + months + " " + days + " - " + number + " - " + name + " - " + "solicitor client draft bill of costs";
                        MessageBox.Show(loc);
                        doc.SaveAs2(loc);

                        //Open new document to edit in the bills form.
                        ap.Visible = true;

                        BillForm billForm = new BillForm();
                        billForm.runStartup(doc, 1, 2);
                        billForm.Show();
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
    }
}
