using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvoRakar.Business.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}