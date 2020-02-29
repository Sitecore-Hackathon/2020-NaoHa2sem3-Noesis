using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.FAQ.Models
{
    public class FAQViewModel
    {
        public List<KeyValuePair<string, string>> ListQuestion { get; set; }

        public FAQViewModel()
        {
            ListQuestion = new List<KeyValuePair<string, string>>();
        }
    }
}