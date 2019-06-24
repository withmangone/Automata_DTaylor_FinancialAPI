using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automata_DTaylor_FinancialAPI.Models
{
    public class Household
    {
        /// <summary>
        /// The primary key for the household
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the household
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A banner to display for the household
        /// </summary>
        public string Greeting { get; set; }
        /// <summary>
        /// When the household was created
        /// </summary>
        public DateTimeOffset Created { get; set; }
        /// <summary>
        /// Whether the household has all the appropriate categories in order to generate transactions. When in doubt, set to false.
        /// </summary>
        public bool IsConfigured { get; set; }
    }
}