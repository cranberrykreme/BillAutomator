using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Handles the entry and alteration of the bill 
    /// of costs professional work.
    /// </summary>
    internal class EntriesModel
    {
        /// <summary>
        /// Represents the date the entry is to be 
        /// set as.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Represents the solicitor that completed
        /// the work in the entry.
        /// </summary>
        public List<SolicitorsModel> solicitor { get; set; } = new List<SolicitorsModel>();

        /// <summary>
        /// Represents the description of
        /// the work that has been completed.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Represents the number of hours 
        /// taken to complete the work.
        /// </summary>
        public double hours { get; set; }

        /// <summary>
        /// Represents the amount that is
        /// to be billed for this
        /// particular entry.
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// Represents the total amount of GST in the 
        /// work done in this entry.
        /// </summary>
        public double GST { get; set; }
    }
}
