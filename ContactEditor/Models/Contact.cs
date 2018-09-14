using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ContactEditor.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [MaxLength(30)]
        public string Person { get; set; }
        public string Phone { get; set; }
        public string PathToImage { get; set; }

    }
}