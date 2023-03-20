using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<Role> role { get; set; }
        public virtual DbSet<BookCategory> bookCategory { get; set; }
        public virtual DbSet<Book> book { get; set; }
        public virtual DbSet<BookChapter> bookChapter { get; set; }
        public virtual DbSet<BookContent> bookContent { get; set; }
        public virtual DbSet<BookComment> bookComment { get; set; }
        public virtual DbSet<Favorite> favorite { get; set; }
        public virtual DbSet<Comment> comment { get; set; }
        public virtual DbSet<Rating> rating { get; set; }
        public virtual DbSet<Report> report { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultDB"));
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }
    }
}
