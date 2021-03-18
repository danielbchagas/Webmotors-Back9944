using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        #region Propriedades de configuração
        private IConfiguration Configuration { get; set; }
        #endregion

        #region DbSets
        public DbSet<Advertising> Advertisings { get; set; }
        #endregion

        #region Contrutores
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder();

            configuration.SetBasePath(System.IO.Directory.GetCurrentDirectory());
            configuration.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
            
            Configuration = configuration.Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("teste_webmotors"), sqlServerOptionsAction: options => {
                    options.EnableRetryOnFailure(maxRetryCount: 6, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
