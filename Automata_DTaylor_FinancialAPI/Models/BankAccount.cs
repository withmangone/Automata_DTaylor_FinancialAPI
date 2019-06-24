using Automata_DTaylor_FinancialPortal.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automata_DTaylor_FinancialAPI.Models
{
    public class BankAccount
    {
        /// <summary>
        /// The primary key for the bank account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key for the associated household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The name of the bank account
        /// </summary>
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        /// <summary>
        /// The type of the bank account
        /// </summary>
        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// How much money the account contained at inception
        /// </summary>
        [Display(Name = "Starting Balance")]
        public decimal StartingBalance { get; set; }
        /// <summary>
        /// The app will send notifications once the current balance meets or falls below this value
        /// </summary>
        [Display(Name = "Low Balance Level")]
        public decimal LowBalanceLevel { get; set; }
        /// <summary>
        /// Set to the same number as the starting balance at inception
        /// </summary>
        [Display(Name = "Current Balance")]
        public decimal CurrentBalance { get; set; }
    }
}