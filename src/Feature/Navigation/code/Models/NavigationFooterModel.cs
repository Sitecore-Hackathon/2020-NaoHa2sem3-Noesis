using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Hackathon.Feature.Navigation.Models
{
    public class NavigationFooterModel
    {
        public string Pinterest { get; set; }
        public string Twitter { get; set; }

        public NavigationFooterModel()
        {
            Pinterest = String.Empty;
            Twitter = String.Empty;
        }
    }
}