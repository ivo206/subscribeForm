using IvoRakar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace IvoRakar.Business.Persistence.Mappings
{
    public class SubscriberMap : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberMap()
        {
            HasKey(x => x.Email);
        }
         
    }
}