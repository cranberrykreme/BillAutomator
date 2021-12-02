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
        public NewEntryForm()
        {
            InitializeComponent();
        }
    }
}
