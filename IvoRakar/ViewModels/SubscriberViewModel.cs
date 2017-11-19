using IvoRakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvoRakar.ViewModels
{
    public class SubscriberViewModel
    {
        public Subscriber Subscriber { get; set; }
        public string ContentHtmlId { get; set; }
        public Status Status { get; set; }

        public SubscriberViewModel()
        {
            Subscriber = new Subscriber();
            Status = new Status();
            ContentHtmlId = "newsletter-form";
        }

        public SubscriberViewModel(Subscriber subscriber) : this()
        {
            Subscriber = subscriber;
        }
    }
}