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
using Word = Microsoft.Office.Interop.Word;
//using BillAutomator;

namespace BillAutomatorUI
{
    /// <summary>
    /// This Form is the basic view that the user will see
    /// when they open a particular file or create a new one.
    /// It gives the user access to all of the other forms, 
    /// such as solicitor and counsel management and adding
    /// new entries and disbursements. Finally, it allows the
    /// user to edit the existing entries.
    /// </summary>
    public partial class BillForm : Form
    {
        public string fileLoc;
        Document doc;

        public BillForm()
        {
            InitializeComponent();
        }

        private void saveCloseButton_Click(object sender, EventArgs e)
        {
            doc.Close();
            this.Close();

        }

        public void runStartup(Document aDoc)
        {
            DashboardForm df = new DashboardForm();
            fileLoc = df.fileName;

            //EntriesModel em = new EntriesModel();

            doc = aDoc;

            

            for(int tab = 2; tab < 4; tab++)
            {
                Word.Table table = doc.Tables[tab];
                Rows rows = table.Rows;
                Columns cols = table.Columns;
                for (int i = 2; i < rows.Count; i++)
                {
                    string ftxt = "";
                    for (int j = 1; j <= cols.Count; j++)
                    {
                        Cell cell = rows[i].Cells[j];
                        Range r = cell.Range;

                        string txt = r.Text;
                        ftxt = ftxt + " | " + txt;
                    }
                    Console.WriteLine(ftxt + "\n");
                }
            }
            
        }

        private bool ValidateForm()
        {
            return true;
        }
    }
}
