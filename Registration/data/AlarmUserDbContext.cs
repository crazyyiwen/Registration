using Microsoft.EntityFrameworkCore;
using Registration.models;

namespace Registration.data
{
    public class AlarmUserDbContext: DbContext
    {
        public AlarmUserDbContext ( DbContextOptions<AlarmUserDbContext> options )
            : base (options)
        {
        }

        // This maps Users table
        public DbSet<User> Users { get; set; } = null!;
    }
}
