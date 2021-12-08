using System;
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
        }

        public void viewApp()
        {
            this.ShowDialog();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        { 

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Open Draft Bill";
                ofd.Filter = "Word Document|*.docx";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //MessageBox.Show(ofd.FileName); //Or safeFileName
                    fileName = ofd.FileName;

                    string days = DateTime.Now.ToString("dd");
                    string months = DateTime.Now.ToString("MM");
                    string year = DateTime.Now.ToString("yyyy");

                    //MessageBox.Show(days + months + year);

                    openFileTextBox.Text = fileName;


                    try
                    {
                    Application ap = new Application();
                    Document document = ap.Documents.Open(@fileName);
                    ap.Visible = true;
                    //System.Diagnostics.Process.Start(@fileName);
                    //this.Application.Documents.Open(@"C:\Test\NewDocument.docx");

                    BillForm billForm = new BillForm();
                    billForm.runStartup(document);
                    billForm.Show();
                    //this.Hide();
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc);
                    }
                

            }
        }

    }
}
