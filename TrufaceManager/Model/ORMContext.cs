using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrufaceManager;
using TrufaceManager.Model;

namespace TrufaceManager
{
    public class ORMContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<ORMContext>(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ORMContext, ContextMigrationConfiguration>(true));
        }
        public ORMContext() : base("ORMContext") { } //配置使用的连接名
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    internal sealed class ContextMigrationConfiguration : DbMigrationsConfiguration<ORMContext>
    {
        public ContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}
