using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomatorUI
{
    /// <summary>
    /// Creates and manages the individual photocopying,
    /// rates that will need to be handled.
    /// </summary>
    public class DisbursementTypeModel
    {
        /// <summary>
        /// Represents type of disbursement.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Represents number of disbursements in the bill that
        /// use this particular type of disbursement.
        /// </summary>
        public int numDisbursements { get; set; }
    }
}
