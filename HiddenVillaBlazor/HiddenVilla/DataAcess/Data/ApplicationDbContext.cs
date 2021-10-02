using Microsoft.EntityFrameworkCore;

namespace DataAcess.Data
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
      {
      }

      public DbSet<HotelRoom> HotelRoms { get; set; }
   }
}
