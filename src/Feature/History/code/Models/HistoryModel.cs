using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Feature.History.Models
{
    public class HistoryModelList
    {
        public List<HistoryModel> ListHistoryMode { get; set; }

        public HistoryModelList()
        {
            ListHistoryMode = new List<HistoryModel>();
        }
    }
    public class HistoryModel
    {
        public int Participants { get; set; }
        public List<Winner> WinnerList { get; set; }
        public List<Team> TeamsList { get; set; }
        public string LinkWinningPages { get; set; }
        public string PicturesLink { get; set; }

        public HistoryModel()
        {
            WinnerList = new List<Winner>();
        }

        public void SetData(Item hackathonData)
        {

            LinkWinningPages = hackathonData.Fields[Templates.Hackathon.Fields.HackathonWinnerPageLink].Value;
            PicturesLink = hackathonData.Fields[Templates.Hackathon.Fields.PicturesLinks].Value;

            foreach (Item item in hackathonData.GetChildren())
            {
                if(item.TemplateID == Templates.Team.Folder.TeamsFolder)
                {                   
                    var teams = item.GetChildren().Count();
                    Participants = teams;                  
                }
                if(item.TemplateID == Templates.Winner.Folder.WinnerFolder)
                {
                    foreach(Item winner in item.GetChildren())
                    {
                        var winnerData = new Winner();
                        winnerData.Topic = Sitecore.Context.Database.GetItem(winner.Fields[Templates.Winner.Fields.WinnerTopic].Value).Name;
                        winnerData.Team = Sitecore.Context.Database.GetItem(winner.Fields[Templates.Winner.Fields.WinnerTeam].Value).Name;
                        winnerData.Photo = winner.Fields[Templates.Winner.Fields.WinnerPhoto].Value;
                        if (winnerData != null)
                            WinnerList.Add(winnerData);
                    }
                }
            } 
        }
    }
}