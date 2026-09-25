using Microsoft.EntityFrameworkCore;

namespace Digital_Literacy_Training_for_Senior_Citizens.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }
    }
}