using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomatorUI
{
    /// <summary>
    /// Represents the subheading that
    /// the disbursement fits into.
    /// </summary>
    public class DisbursementsModel
    {
        /// <summary>
        /// Represents the subheading that
        /// the disbursement fits into.
        /// </summary>
        public DisbursementTypeModel typeOfDisbursement { get; set; }

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

        /// <summary>
        /// Represents the date that the disbursement
        /// was billed on.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Represents the amount that the disbursement
        /// was billed at.
        /// </summary>
        public double amount { get; set; }
    }
}
