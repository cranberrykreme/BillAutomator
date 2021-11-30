using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    internal class SolicitorsModel
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string initials { get; set; }

        public List<double> hourlyRates { get; set; }

        public DateTime dateOfAdmission { get; set; }

        public List<DateTime> datesOfHourlyRates { get; set; }
    }
}
