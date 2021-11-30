using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Takes care of the process of entering information into the 
    /// disbursements table, when the disbursement is by counsel.
    /// </summary>
    internal class CounselDisbursementsModel
    {
        /// <summary>
        /// Represents the number of hours that 
        /// counsel worked on this entry.
        /// </summary>
        public double numberOfHours { get; set; }

        /// <summary>
        /// Represents the specific
        /// counsel that worked on this entry.
        /// </summary>
        public List<CounselModel> counsel { get; set; } = new List<CounselModel>();

        /// <summary>
        /// Represents the amount of GST in the 
        /// entry.
        /// </summary>
        public double GST { get; set; }

        /// <summary>
        /// Represents the total cost of
        /// the entry.
        /// </summary>
        public double totalAmount { get; set; }

        /// <summary>
        /// Represents the date that the entry
        /// was completed on.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Represents the description of
        /// the work completed in the entry.
        /// </summary>
        public string description { get; set; }
    }
}
