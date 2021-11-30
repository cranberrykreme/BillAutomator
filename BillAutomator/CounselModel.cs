using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Creates and manages all of the different counsel's that
    /// are relevant to this file.
    /// </summary>
    internal class CounselModel
    {
        /// <summary>
        /// Represents counsels first name.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Represents counsels last name.
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Represents counsels hourly rate.
        /// </summary>
        public double hourlyRate { get; set; }
    }
}
