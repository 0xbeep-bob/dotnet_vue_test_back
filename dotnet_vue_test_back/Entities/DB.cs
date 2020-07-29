using dotnet_vue_test_back.Entities.Helpers;
using dotnet_vue_test_back.Entities.Tables;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace dotnet_vue_test_back.Entities
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqliteConnectionStringBuilder()
            {
                DataSource = Path.Combine(AppContext.BaseDirectory, "Db.db"),
                Cache = SqliteCacheMode.Shared,
                Mode = SqliteOpenMode.ReadWriteCreate,
            };
            optionsBuilder.UseSqlite(builder.ConnectionString, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(FillTablesHelper.Instance.FillUsers());

            base.OnModelCreating(modelBuilder);
        }
    }
}
