using Automata_DTaylor_FinancialPortal.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automata_DTaylor_FinancialAPI.Models
{
    public class Transaction
    {
        /// <summary>
        /// The primary key of the transaction
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The foreign key for the associated bank account
        /// </summary>
        public int BankAccountId { get; set; }
        /// <summary>
        /// The foreign key for the associated budget category id
        /// </summary>
        public int? BudgetCategoryItemId { get; set; }
        /// <summary>
        /// The id of the user responsible for generating the transaction
        /// </summary>
        public string CreatedById { get; set; }
        /// <summary>
        /// The dollar value of the transaction
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Various transaction types, primarily used to inform whether the amount should be added or subtracted from the bank account's current balance
        /// </summary>
        public TransactionType TransactionType { get; set; }
        /// <summary>
        /// The recipient of the funds
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// A field for the user to leave a note about the transaction
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// When the transaction occurred
        /// </summary>
        public DateTimeOffset Created { get; set; }
        /// <summary>
        /// Whether or not the transaction has been updated
        /// </summary>
        public bool Reconciled { get; set; }
        /// <summary>
        /// When the transaction was updated
        /// </summary>
        public DateTimeOffset? ReconciledDate { get; set; }
    }
}