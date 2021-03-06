using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Handles all of the different solicitors who worked
    /// on/with this file, allowing users to change the hourly
    /// rate for certain time periods and other relevant info.
    /// </summary>
    internal class SolicitorsModel
    {
        /// <summary>
        /// Represents the first name of 
        /// the solicitor.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Represents the last name of
        /// the solicitor.
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Represents the initials of the 
        /// solicitor.
        /// </summary>
        public string initials { get; set; }

        /// <summary>
        /// Represents the hourly rate
        /// of the solicitor.
        /// </summary>
        public List<double> hourlyRates { get; set; }

        /// <summary>
        /// Represents the date of admision
        /// of the solicitor.
        /// </summary>
        public DateTime dateOfAdmission { get; set; }

        /// <summary>
        /// Represents the dates of the different,
        /// hourly rates which the solicitors have
        /// charged over the course of the bill.
        /// </summary>
        public List<DateTime> datesOfHourlyRates { get; set; }
    }
}
