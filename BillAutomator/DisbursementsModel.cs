using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Allows the user to enter disbursements into certain 
    /// categories of disbursement.
    /// </summary>
    internal class DisbursementsModel
    {
        /// <summary>
        /// Represents the subheading that
        /// the disbursement fits into.
        /// </summary>
        public string typeOfDisbursement { get; set; }

        /// <summary>
        /// Represents the description of
        /// the disbursement.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Represents the amount of GST 
        /// payable in the current entry.
        /// </summary>
        public double GST { get; set; }
    }
}
