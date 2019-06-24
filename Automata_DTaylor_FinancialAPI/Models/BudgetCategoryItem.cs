using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automata_DTaylor_FinancialAPI.Models
{
    public class BudgetCategoryItem
    {
        /// <summary>
        /// The primary key for the budget category item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key for the associated budget category
        /// </summary>
        public int BudgetCategoryId { get; set; }
        /// <summary>
        /// The name of the budget category item
        /// </summary>
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
    }
}