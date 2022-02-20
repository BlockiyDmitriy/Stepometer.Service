using Service.DAL.Entity;
using System.Data.Entity;

namespace Service.DAL.Context
{
    public class StepContext : DbContext
    {
        public StepContext() : base("StepometrDB")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Achieve> Achieves { get; set; }
        public DbSet<DataSteps> DataSteps { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<HistoryUserParam> HistoryUserParams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friends>().HasKey(p => new { p.AccId1, p.AccId2});
        }
    }
}
