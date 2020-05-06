using System;
using Microsoft.EntityFrameworkCore;
using ApiMeetignow.Domain.Entitys;
using System.Linq;

namespace ApiMeetignow.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Agenda> Agendas { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dataCreate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dataCreate").CurrentValue = DateTime.Now;
                    entry.Property("dataUpDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dataUpDate").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
