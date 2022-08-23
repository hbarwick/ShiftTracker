using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace ShiftTrackerAPI.Models
{
    public class ShiftContext : DbContext
    {
        public ShiftContext(DbContextOptions<ShiftContext> options)
            : base(options)
        {
        }

        public DbSet<Shift> Shifts { get; set; } = null!;

        //public string DbPath { get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(@"Data Source=(localdb)\localdb;Integrated Security=true;Database=Shifts");

    }
}
