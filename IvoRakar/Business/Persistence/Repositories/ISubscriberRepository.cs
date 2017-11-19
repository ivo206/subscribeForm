using IvoRakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvoRakar.Business.Persistence.Repositories
{
    public interface ISubscriberRepository
    {
        Subscriber Get(string email);

        void Add(Subscriber subscriber);
    }
}
