using Microsoft.EntityFrameworkCore;

namespace IndicesReferentialApi.Models
{
    public class FinancialIndexContext : DbContext
    {
        public FinancialIndexContext(DbContextOptions<FinancialIndexContext> options)
            : base(options)
        {
        }

        public DbSet<FinancialIndex> FinancialIndices { get; set; }
    }
}

