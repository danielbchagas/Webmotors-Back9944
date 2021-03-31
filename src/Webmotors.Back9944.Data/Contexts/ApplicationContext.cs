using Microsoft.EntityFrameworkCore;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Advertising> Advertisings { get; set; }
        
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
