using System.Data.Entity;

namespace BankTransaction.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<MasterRecord> MasterRecords { get; set; }
        public DbSet<DetailRecord> DetailRecords { get; set; }
    }
}
