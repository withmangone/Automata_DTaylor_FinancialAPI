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
    [RoutePrefix("api/Household")]
    public class HouseholdsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retrieves all data with associated household id.
        /// </summary>
        /// <param name="id">PK for the household.</param>
        /// <returns></returns>
        [Route("GetData")]
        public async Task<Household> GetHouseholdData(int id)
        {
            var myHouseData = await db.GetHouseholdData(id);

            return myHouseData;
        }
    }
}
