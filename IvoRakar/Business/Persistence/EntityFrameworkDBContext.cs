using IvoRakar.Business.Persistence.Mappings;
using IvoRakar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IvoRakar.Business.Persistence
{
    public class EntityFrameworkDBContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }

        public EntityFrameworkDBContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SubscriberMap());
        }
    }
}