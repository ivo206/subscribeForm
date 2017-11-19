using IvoRakar.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvoRakar.Models
{
    public class Status
    {
        public string Message { get; set; }
        public StatusType Type { get; set; }
    }
}