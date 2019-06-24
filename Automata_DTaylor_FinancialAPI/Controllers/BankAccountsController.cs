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
    [RoutePrefix("api/BankAccount")]
    public class BankAccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves all bank account data associated with a bank account id.
        /// </summary>
        /// <param name="id">PK for the bank account in question.</param>
        /// <returns></returns>
        [Route("GetDetails")]
        public async Task<BankAccount> GetAccountDetailsAsync(int id)
        {
            var myAccountDetails = await db.GetAccountDetails(id);

            return myAccountDetails;
        }

        /// <summary>
        /// Retrieves all bank accounts associated with a household id.
        /// </summary>
        /// <param name="householdId">FK for the associated household.</param>
        /// <returns></returns>
        [Route("GetAccounts")]
        public async Task<List<BankAccount>> GetAccountsAsync(int householdId)
        {
            var myAccounts = await db.GetAccounts(householdId);

            return myAccounts;
        }

        /// <summary>
        /// Adds a bank account.
        /// </summary>
        /// <param name="householdId">FK for the associated household.</param>
        /// <param name="accountName">The title of the account. Character limit of 40.</param>
        /// <param name="accountType">The type of the account. See models tab for option list.</param>
        /// <param name="startingBalance">How much money the account contained at inception.</param>
        /// <param name="lowBalanceLevel">The app will send notifications once the current balance meets or falls below this value.</param>
        /// <param name="currentBalance">Set to the same number as the starting balance at inception.</param>
        /// <returns></returns>
        [Route("AddAccount")]
        [AcceptVerbs("GET", "POST")]
        public async Task<IHttpActionResult> AddAccountAsync(int householdId, string accountName, int accountType, decimal startingBalance, decimal lowBalanceLevel, decimal currentBalance)
        {
            return Ok(await db.AddAccount(householdId, accountName, accountType, startingBalance, lowBalanceLevel, currentBalance));
        }

        /// <summary>
        /// Update a bank account's current balance.
        /// </summary>
        /// <param name="id">PK for the bank account.</param>
        /// <param name="transAmount">The transaction amount.</param>
        /// <param name="transType">The type of the transaction. See models tab for option list.</param>
        /// <returns></returns>
        [Route("UpdateAccount")]
        [AcceptVerbs("PUT")]
        public async Task<IHttpActionResult> UpdateAccountAsync(int id, decimal transAmount, int transType)
        {
            return Ok(await db.UpdateAccount(id, transAmount, transType));
        }
    }
}
