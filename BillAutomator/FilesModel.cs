using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomator
{
    /// <summary>
    /// Takes care of the opening, saving and creation
    /// of bill of cost's files.
    /// </summary>
    internal class FilesModel
    {
        /// <summary>
        /// Represents the location that the 
        /// temaplate bill is received from.
        /// </summary>
        public string templateLocation { get; set; }

        /// <summary>
        /// Represents the location to retrieve
        /// as saved file from.
        /// </summary>
        public string retrieveFileLocation { get; set; }

        /// <summary>
        /// Represents the location to save the 
        /// file once work is completed.
        /// </summary>
        public string saveAs { get; set; }
    }
}
