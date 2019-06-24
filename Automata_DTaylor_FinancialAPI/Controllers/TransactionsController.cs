using Automata_DTaylor_FinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Automata_DTaylor_FinancialAPI.Controllers
{
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves all details associated with a transaction id.
        /// </summary>
        /// <param name="id">PK for the transaction.</param>
        /// <returns></returns>
        [Route("GetDetails")]
        public async Task<Transaction> GetTransactionDetails(int id)
        {
            var myTransactionDetails = await db.GetTransactionDetails(id);

            return myTransactionDetails;
        }

        /// <summary>
        /// Retrieves all transactions associated with a bank account id.
        /// </summary>
        /// <param name="accountId">FK for the associated bank account.</param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            var myAccounts = await db.GetTransactions(accountId);

            return myAccounts;
        }

        /// <summary>
        /// Adds a transaction.
        /// </summary>
        /// <param name="bankAccountId">FK for the associated bank account.</param>
        /// <param name="budgetCategoryItemId">FK for the associated budget category item.</param>
        /// <param name="createdById">The ID of the user that created the transaction. Character limit of 128.</param>
        /// <param name="amount">The amount of the transaction.</param>
        /// <param name="transactionType">The type of the transaction. See models tab for option list.</param>
        /// <param name="payee">The recipient of the transaction.</param>
        /// <param name="memo">A field for the user to leave a note about the transaction.</param>
        /// <param name="created">The time and date of the transaction.</param>
        /// <param name="reconciled">Whether the transaction has been adjusted. Default to false.</param>
        /// <param name="reconciledDate">The time and date of the transaction adjustment.</param>
        /// <returns></returns>
        [Route("AddTransaction")]
        [AcceptVerbs("GET", "POST")]
        public async Task<IHttpActionResult> AddTransactionAsync(int bankAccountId, int? budgetCategoryItemId, string createdById, decimal amount, int transactionType, string payee, string memo, DateTimeOffset created, bool reconciled, DateTimeOffset? reconciledDate)
        {
            return Ok(await db.AddTransaction(bankAccountId, budgetCategoryItemId, createdById, amount, transactionType, payee, memo, created, reconciled, reconciledDate));
        }

        /// <summary>
        /// Delete a transaction.
        /// </summary>
        /// <param name="id">PK for the transaction to delete.</param>
        /// <returns></returns>
        [Route("DeleteTransaction")]
        [AcceptVerbs("DELETE")]
        public async Task<IHttpActionResult> DeleteTransactionAsync(int id)
        {
            return Ok(await db.DeleteTransaction(id));
        }
    }
}
