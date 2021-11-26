using Age_Tur.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Age_Tur.Infra.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterAllEntities<Entity>(modelBuilder, Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        private static void RegisterAllEntities<BaseType>(ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(a => a.GetExportedTypes())
                                  .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

            foreach (var type in types)
                modelBuilder.Entity(type);
        }

    }
}
