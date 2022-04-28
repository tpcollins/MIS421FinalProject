using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProject.Models;

namespace MIS421FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MIS421FinalProject.Models.Exercise> Exercise { get; set; }
        public DbSet<MIS421FinalProject.Models.Food> Food { get; set; }
        public DbSet<MIS421FinalProject.Models.MyExercise> MyExercise { get; set; }
        public DbSet<MIS421FinalProject.Models.MyFood> MyFood { get; set; }
    }
}