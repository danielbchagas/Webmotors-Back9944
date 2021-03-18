using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Data
{
    public class ApplicationContext : DbContext
    {
        #region Propriedades de configuração
        private static readonly ILoggerFactory EFLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
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
                optionsBuilder.UseLoggerFactory(EFLoggerFactory);
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
