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
            openingNew = true;
            this.Close();
        }
    }
}
