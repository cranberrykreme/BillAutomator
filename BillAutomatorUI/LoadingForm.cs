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
    public partial class LoadingForm : Form
    {
        private static int totalLength;
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void totalLoading(int aTotalLength)
        {
            totalLength = aTotalLength;
            loadingBar.Maximum = totalLength;
            loadingBar.Step = 1;
            loadingBar.Value = 0;
        }

        public void progressDisplay()
        {
            // Updating loadingbar if value is less than the maximum.
            if(loadingBar.Value < loadingBar.Maximum)
            {
                loadingBar.Value++;
                int progress = (loadingBar.Value * 100) / (totalLength);

                progressLabel.Text = progress.ToString() + "%";
            }
            
        }
    }
}
