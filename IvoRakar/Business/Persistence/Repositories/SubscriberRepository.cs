using IvoRakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvoRakar.Business.Persistence.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly EntityFrameworkDBContext _context;

        public SubscriberRepository(EntityFrameworkDBContext context)
        {
            _context = context;
        }

        public Subscriber Get(string email)
        {
            return _context.Subscribers.Find(email);
        }

        public void Add(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
        }
    }
}