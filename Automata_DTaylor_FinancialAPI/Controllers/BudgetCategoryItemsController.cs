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
    [RoutePrefix("api/BudgetCategoryItems")]
    public class BudgetCategoryItemsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieve all data associated with a budget category item id.
        /// </summary>
        /// <param name="id">PK for the budget category item.</param>
        /// <returns></returns>
        [Route("GetDetails")]
        public async Task<BudgetCategoryItem> GetBudgetItemDetails(int id)
        {
            var myBudgetItemDetails = await db.GetBudgetItemDetails(id);

            return myBudgetItemDetails;
        }

        /// <summary>
        /// Retrieve all budget category items associated with a budget category id.
        /// </summary>
        /// <param name="budgetCategoryItemId">FK for the associated budget category.</param>
        /// <returns></returns>
        [Route("GetBudgetCategoryItems")]
        public async Task<List<BudgetCategoryItem>> GetBudgetItems(int budgetCategoryItemId)
        {
            var myBudgetItems = await db.GetBudgetItems(budgetCategoryItemId);

            return myBudgetItems;
        }
    }
}
