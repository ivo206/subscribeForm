using IvoRakar.Business.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IvoRakar.Models
{
    public class Subscriber
    {
        [Required(ErrorMessage = "The e-mail field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to specify how you heard about us.")]
        public MarketingTool? MarketingTool { get; set; }

        public string Resason { get; set; }

        public Subscriber()
        {
            Email = "";
        }
    }
}