using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomatorUI
{
    /// <summary>
    /// Handles the entry and alteration of the bill 
    /// of costs professional work.
    /// </summary>
    public class EntriesModel
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
            public SolicitorsModel solicitor { get; set; } = new SolicitorsModel();

            /// <summary>
            /// Represents that this was a completed photocopying
            /// work in the entry.
            /// </summary>
            public PhotocopyModel photocopy { get; set; } = new PhotocopyModel();

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

            /// <summary>
            /// Represents the percentage amount that is claimed,
            /// compared to the total amount owed for the hours * hourly rate.
            /// </summary>
            public double percentage { get; set; }

            /// <summary>
            /// Represents whether the specific entry has no charge or not.
            /// </summary>
            public bool noCharge { get; set; }

            /// <summary>
            /// Represents whether the entry has been changed since it was read from the word document.
            /// </summary>
            public bool changed { get; set; }

            /// <summary>
            /// Represents whether the entry is photocopying or not
            /// </summary>
            public bool isPhotocopy { get; set; }
    }
}

