using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automata_DTaylor_FinancialAPI.Models
{
    public class BudgetCategory
    {
        /// <summary>
        /// The primary key for the budget category
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key for the associated household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The name of the budget category
        /// </summary>
        [Display(Name = "Budget Category Name")]
        public string BudgetCategoryName { get; set; }
        /// <summary>
        /// The target budget for the budget category (the sum of the transactions within this category's category items)
        /// </summary>
        [Display(Name = "Target Amount")]
        public decimal TargetAmount { get; set; }
    }
}