using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomatorUI
{
    /// <summary>
    /// Represents the entirety of the bill, from the entries,
    /// to the relevant solicitors
    /// </summary>
    public class BillModel
    {

        /// <summary>
        /// Represents the list of solicitors that are
        /// present in the bill of costs.
        /// </summary>
        public List<SolicitorsModel> solicitor { get; set; } = new List<SolicitorsModel>();

        /// <summary>
        /// Represents the list of entries that are in the bill.
        /// </summary>
        public List<EntriesModel> entries { get; set; } = new List<EntriesModel>();

        /// <summary>
        /// Represents the list of disbursements that are in the bill.
        /// </summary>
        public List<DisbursementsModel> disbursements  { get; set; } = new List<DisbursementsModel>();

        /// <summary>
        /// Represents the list of photocopying rates for the matter.
        /// </summary>
        public List<PhotocopyModel> photocopies { get; set; } = new List<PhotocopyModel>();
    }
}
