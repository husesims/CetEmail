using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CetEmail.Models
{
    public class MailModel
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }
        public string Subject { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
