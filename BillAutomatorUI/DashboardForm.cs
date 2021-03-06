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
//using DocumentFormat.OpenXml.Wordprocessing;
//using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
//using BillAutomator;

namespace BillAutomatorUI
{
    /// <summary>
    /// This is where the application will open, it will
    /// link to existing files or allow the user to open
    /// a new bill. 
    /// </summary>
    public partial class DashboardForm : Form
    {
        public string fileName;

        public DashboardForm()
        {
            InitializeComponent();

            hasDisbursementsCheckBox.Checked = true;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {

            bool newDate = false;
            string newFileName = "No";

            OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Open Draft Bill";
                ofd.Filter = "Word Document|*.docx";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                //MessageBox.Show(ofd.FileName); //Or safeFileName
                fileName = ofd.FileName;
                fileLocTextBox.Text = fileName;

                string fileDays = "";
                string fileMonths = "";
                string fileYears = "";

                try
                {
                    string days = DateTime.Now.ToString("dd");
                    string months = DateTime.Now.ToString("MM");
                    string years = DateTime.Now.ToString("yyyy");

                    // Get the date listed on the file.
                    string[] names = fileName.Split('\\');
                    string name = names[names.Length - 1];

                    string[] dates = name.Split('-');
                    string date = dates[0];

                    // Get days, months and year.
                    string[] individualDates = date.Split(' ');
                    fileDays = individualDates[2];
                    fileMonths = individualDates[1];
                    fileYears = individualDates[0];

                    if (!String.Equals(days, fileDays) || !String.Equals(months, fileMonths) || !String.Equals(years, fileYears))
                    {
                        //Save a string with the new/updated fileName.
                        individualDates[0] = years;
                        individualDates[1] = months;
                        individualDates[2] = days;

                        date = String.Join(" ", individualDates);
                        dates[0] = date;

                        name = String.Join("-", dates);
                        names[names.Length - 1] = name;

                        newFileName = String.Join(@"\", names);

                        newDate = true;
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Error with reading the title.");
                    Console.WriteLine("Error with reading the title.\n\n" + ex);
                    return;
                }



                try
                    {
                    Application ap = new Application();
                    Document document;
                    try
                    {
                        document = ap.Documents.Open(@fileName);
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Cannot open the file, please close the file if you currently have it open");
                        return;
                    }
                    

                    // If new save name, then save the document.
                    if (newDate && !String.Equals(newFileName,"No"))
                    {
                        try
                        {
                            if (!File.Exists(@newFileName))
                            {
                                try
                                {
                                    document.SaveAs2(@newFileName);
                                    MessageBox.Show("Document saved with new date.");
                                    fileName = newFileName;
                                } catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    document.Close();
                                    return;
                                }
                                
                            }
                            else
                            {

                                if (MessageBox.Show("There exists a bill with today's date, the one you have opened has the date: " +
                                    fileDays + " " + fileMonths + " " + fileYears + "\n\n" + "Would you Like to continue?", 
                                    "Open File Confirmation",
                                MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    document.Close();
                                    return;
                                }
                                else
                                {
                                    try
                                    {
                                        document.SaveAs2(@newFileName);
                                        MessageBox.Show("Document saved with new date.");
                                        fileName = newFileName;
                                    } catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                        MessageBox.Show("Cannot save file with todays date, perhaps you already have one open?");
                                        document.Close();
                                        return;
                                    }
                                    
                                }
                            }
                            
                        } catch (Exception ex)
                        {
                            MessageBox.Show("Document Could Not be opened and saved with today's date. " + ex.ToString());
                            document.Close();
                            return;
                        }
                        
                    }

                    ap.Visible = true;
                    //System.Diagnostics.Process.Start(@fileName);
                    //this.Application.Documents.Open(@"C:\Test\NewDocument.docx");

                    BillForm billForm = new BillForm();
                    billForm.runStartup(document, fileName, 0, 0, 0, hasDisbursementsCheckBox.Checked);

                    billForm.Show();
                    //this.Hide();
                }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Line 176: " + exc);
                    }
                

            }
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            CreateNewForm newForm = new CreateNewForm();
            newForm.runStartup();
            newForm.Show();
        }
    }
}
