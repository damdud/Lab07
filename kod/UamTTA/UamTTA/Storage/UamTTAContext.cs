using System.Data.Entity;
using UamTTA.Model;

namespace UamTTA.Storage
{
    public class UamTTAContext : DbContext
    {
        public UamTTAContext() : base("UamTTAContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Transfer> Transfers { get; set; }

        public DbSet<BudgetTemplate> Templates { get; set; }
    }
}