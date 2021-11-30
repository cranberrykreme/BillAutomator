using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    internal class EntriesModel
    {
        public DateTime date { get; set; }

        public List<SolicitorsModel> solicitor { get; set; } = new List<SolicitorsModel>();

        public string description { get; set; }

        public double hours { get; set; }

        public double amount { get; set; }
    }
}
