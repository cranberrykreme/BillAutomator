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
    public class PhotocopyModel
    {
        /// <summary>
        /// Represents starting rate for the photocopying.
        /// </summary>
        public double initialRate { get; set; }

        /// <summary>
        /// Represents the page at which the rate changes.
        /// </summary>
        public int pageRateChange { get; set; }

        /// <summary>
        /// Represents rate of photocopying per page after the rate change page.
        /// </summary>
        public double secondRate { get; set; }
    }
}
