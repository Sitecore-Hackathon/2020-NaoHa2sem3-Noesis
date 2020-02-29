using Hackathon.Feature.History.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace Hackathon.Feature.History.Controllers
{
    public class HistoryController : Controller
    {
        public ActionResult Index()
        {
            object result;

            HistoryModelList modelList = new HistoryModelList();
            var model = new HistoryModel();
            var dataSource = Sitecore.Context.Item;
            if (dataSource.TemplateID == Templates.Page.ID)
            {
                var hackathonItems = dataSource.GetChildren().ToList().Find(x => x.TemplateID.ToString() == Templates.Hackathon.Folder.ToString()).GetChildren();
                foreach(Item item in hackathonItems)
                {
                    if (item != null)
                    {
                        
                        var itemData = item.Fields[Templates.Hackathon.Fields.HackathonData].Value;
                        var data = Sitecore.Context.Database?.GetItem(itemData);
                        model.SetData(data);
                        modelList.ListHistoryMode.Add(model);
                    }
                }
            }
            else
            {
                result = dataSource;
            }
            return View("History", model);
        }
    }
}