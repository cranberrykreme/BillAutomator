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
    public partial class CreateNewForm : Form
    {
        /// <summary>
        /// Accessed from the dashboard page, this will get the user to
        /// choose the location to create a new file, as well as getting them
        /// to determine the name/number and type of bill to create.
        /// It will also allow users to return to the dashboard form.
        /// </summary>
        public CreateNewForm()
        {
            InitializeComponent();
        }

        private void fileLocationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.Description = "Choose clients file to save in";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
            }
        }
    }
}
