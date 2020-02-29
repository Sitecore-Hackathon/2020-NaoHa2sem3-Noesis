using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Feature.FAQ.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Feature.FAQ.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult Index()
        {
            var model = new FAQViewModel();
            var rootItem = RenderingContext.CurrentOrNull.Rendering.DataSource;
            Item dataSourceItem = Sitecore.Context.Database.GetItem(rootItem);

            if (dataSourceItem != null)
            {
                foreach (Item item in dataSourceItem.GetChildren())
                {
                    model.ListQuestion.Add(new KeyValuePair<string, string>(item.Fields[Templates.FAQ.Fields.Question].Value, item.Fields[Templates.FAQ.Fields.Answer].Value));
                }
            }

            return View("FAQView", model);
        }
    }
}