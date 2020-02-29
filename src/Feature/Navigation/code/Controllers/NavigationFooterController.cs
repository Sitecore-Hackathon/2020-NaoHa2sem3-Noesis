using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Hackathon.Feature.Navigation.Models;

namespace Hackathon.Feature.Navigation.Controllers
{
    public class NavigationFooterController : Controller
    {
        // GET: NavigationFooter
        public ActionResult Index()
        {
            var rootItem = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var item = Sitecore.Context.Database.GetItem(rootItem);
            var model = new NavigationFooterModel();
            if (item != null)
            {
                var pinterestLink = (LinkField)item.Fields[Templates.NavigationFooter.Fields.Pinterest];
                var twitterLink = (LinkField)item.Fields[Templates.NavigationFooter.Fields.Twitter];
                var pinterestUrl = "";
                var twitterUrl = "";
                if (pinterestLink.LinkType.Contains("external") || twitterLink.LinkType.Contains("external"))
                {
                    pinterestUrl = pinterestLink.Url;
                    twitterUrl = twitterLink.Url;
                }
                else if (pinterestLink.LinkType.Contains("internal") || twitterLink.LinkType.Contains("internal"))
                {
                    var pinterestUrltarget = Sitecore.Context.Database.GetItem(pinterestLink.TargetID);
                    var twitterUrltarget = Sitecore.Context.Database.GetItem(twitterLink.TargetID);
                    pinterestUrl = LinkManager.GetItemUrl(pinterestUrltarget);
                    twitterUrl = LinkManager.GetItemUrl(twitterUrltarget);
                }
                model.Pinterest = pinterestUrl;
                model.Twitter = twitterUrl;
            }

            return View("NavigationFooter", model);
        }
    }
}