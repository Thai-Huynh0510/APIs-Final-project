using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ProjectN.Models;

namespace ProjectN.Models
{
    public class FunkoDBConext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public FunkoDBConext(DbContextOptions<FunkoDBConext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("funkodata");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Funkopop>  Funkopop{ get; set; } = null!;
        public DbSet<FunkoValue> FunkoValues { get; set; } = null!;
    }
}
