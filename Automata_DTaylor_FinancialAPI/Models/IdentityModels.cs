using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Automata_DTaylor_FinancialAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //SQL Get Household
        public async Task<Household> GetHouseholdData(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdData @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetCategory>> GetHouseholdBudgets(int id)
        {
            return await Database.SqlQuery<BudgetCategory>("GetHouseholdBudgets @id", new SqlParameter("id", id)).ToListAsync();
        }

        public async Task<BankAccount> GetAccountDetails(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetAccounts(int householdId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccounts @householdId", new SqlParameter("householdId", householdId)).ToListAsync();
        }

        public async Task<BudgetCategory> GetBudgetDetails(int id)
        {
            return await Database.SqlQuery<BudgetCategory>("GetBudgetDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<BudgetCategoryItem> GetBudgetItemDetails(int id)
        {
            return await Database.SqlQuery<BudgetCategoryItem>("GetBudgetItemDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetCategoryItem>> GetBudgetItems(int budgetCategoryItemId)
        {
            return await Database.SqlQuery<BudgetCategoryItem>("GetBudgetItems @budgetCategoryItemId", new SqlParameter("budgetCategoryItemId", budgetCategoryItemId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id", new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @accountId", new SqlParameter("accountId", accountId)).ToListAsync();
        }

        public async Task<int> AddAccount(int householdId, string accountName, int accountType, decimal startingBalance, decimal lowBalanceLevel, decimal currentBalance)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @householdId, @accountName, @accountType, @startingBalance, @lowBalanceLevel, @currentBalance",
                new SqlParameter("householdId", householdId),
                new SqlParameter("accountName", accountName),
                new SqlParameter("accountType", accountType),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("lowBalanceLevel", lowBalanceLevel),
                new SqlParameter("currentBalance", currentBalance)
                );
        }

        public async Task<int> AddBudget(int householdId, string budgetCategoryName, decimal targetAmount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @householdId, @budgetCategoryName, @targetAmount",
                new SqlParameter("householdId", householdId),
                new SqlParameter("budgetCategoryName", budgetCategoryName),
                new SqlParameter("targetAmount", targetAmount)
                );
        }

        public async Task<int> AddTransaction(int bankAccountId, int? budgetCategoryItemId, string createdById, decimal amount, int transactionType, string payee, string memo, DateTimeOffset created, bool reconciled, DateTimeOffset? reconciledDate)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @bankAccountId, @budgetCategoryItemId, @createdById, @amount, @transactionType, @payee, @memo, @created, @reconciled, @reconciledDate",
                new SqlParameter("bankAccountId", bankAccountId),
                new SqlParameter("budgetCategoryItemId", budgetCategoryItemId),
                new SqlParameter("createdById", createdById),
                new SqlParameter("amount", amount),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("payee", payee),
                new SqlParameter("memo", memo),
                new SqlParameter("created", created),
                new SqlParameter("reconciled", reconciled),
                new SqlParameter("reconciledDate", reconciledDate)
                );
        }

        public async Task<int> UpdateAccount(int id, decimal transAmount, int transType)
        {
            return await Database.ExecuteSqlCommandAsync("UpdateAccount @id, @transAmount, @transType",
                new SqlParameter("id", id),
                new SqlParameter("transAmount", transAmount),
                new SqlParameter("transType", transType)
                );
        }

        public async Task<int> DeleteTransaction(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteTransaction @id",
                new SqlParameter("id", id)
                );
        }
    }
}