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
    [RoutePrefix("api/BudgetCategory")]
    public class BudgetCategoryController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves all budget categories associated with a household id.
        /// </summary>
        /// <param name="id">FK for the associated household.</param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<BudgetCategory>> GetHouseholdBudgets(int id)
        {
            var budgetCategories = await db.GetHouseholdBudgets(id);

            return budgetCategories;
        }

        /// <summary>
        /// Retrieves all data associated with a budget category id.
        /// </summary>
        /// <param name="id">PK for the budget category.</param>
        /// <returns></returns>
        [Route("GetDetails")]
        public async Task<BudgetCategory> GetBudgetDetails(int id)
        {
            var budgetCategory = await db.GetBudgetDetails(id);

            return budgetCategory;
        }

        /// <summary>
        /// Adds a budget.
        /// </summary>
        /// <param name="householdId">FK for the household id.</param>
        /// <param name="budgetCategoryName">The name of the budget category. Character limit of 40.</param>
        /// <param name="targetAmount">The target budget for the budget category (the sum of the transactions within this category's category items).</param>
        /// <returns></returns>
        [Route("AddBudget")]
        [AcceptVerbs("GET", "POST")]
        public async Task<IHttpActionResult> AddBudgetAsync(int householdId, string budgetCategoryName, decimal targetAmount)
        {
            return Ok(await db.AddBudget(householdId, budgetCategoryName, targetAmount));
        }
    }
}
