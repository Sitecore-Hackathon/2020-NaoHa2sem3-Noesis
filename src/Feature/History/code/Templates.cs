using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Hackathon.Feature.History
{
  public struct Templates
  {

        public struct Page
        {
            public static readonly ID ID = new ID("{3B9F1A03-A48E-4712-A026-66F07E19F04F}");
        }
        public struct Hackathon
        {
            public static readonly ID Id = new ID("{256212EF-881D-4175-AD69-13905FE3E25D}");
            public static readonly ID Folder = new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}");
            public static readonly ID HackathonFolder = new ID("{A770D292-46A5-4E05-A68B-6825C22D73DE}");
            public static readonly ID TopicsFolder = new ID("{1237EA09-0F41-4EDE-BE68-A8DAA51D6046}");
            public struct Fields
        {
            public static readonly ID Title = new ID("{88B3D959-1A94-4780-B851-EB4A8779E049}");
            public static readonly ID Description = new ID("{EA74C144-2753-4CE2-8502-57FFE0C01FF0}");
            public static readonly ID Logo = new ID("{85AFA0AA-34D1-4555-8F86-80323FBEC0D7}");
            public static readonly ID BeginDate = new ID("{72F83ED4-1949-4984-B384-7BBE0AD77072}");
            public static readonly ID EndDate = new ID("{B6CAD396-FAE9-4D55-8E35-2DA894E3F440}");
            public static readonly ID PicturesLinks = new ID("{30B60DB3-75CD-4AC6-8619-3E92A1692C86}");
            public static readonly ID HackathonData = new ID("{501B2EDE-78A5-4D72-862A-F42E449CC38E}");
            public static readonly ID HackathonWinnerPageLink = new ID("{DB0CFD86-8E44-47AE-8BF4-E8B8D692D376}");
        }
    }
    public struct Team
    {
        public struct Folder
        {
            public static readonly ID TeamsFolder = new ID("{2D062313-06AB-4A31-B473-9627CDC683B7}");
            public static readonly ID Team = new ID("{25D09680-58D4-4E81-8B44-C26E713F8171}");
        }
        public struct Fields
        {
            public static readonly ID TeamName = new ID("{C9325C96-70AA-48E3-9974-9DE87099A778}");
            public static readonly ID TeamDescription = new ID("{5BAF8ACB-EE08-4BB9-A568-BE472410A2BD}");
            public static readonly ID TeamLogo = new ID("{19F1730F-1672-4B72-B583-FF7F8DAB1ED5}");
            public static readonly ID TeamSubmissionDate = new ID("{343635C8-B0EF-4603-95D8-F5C9310FCE2F}");
            public static readonly ID TeamVideoLink = new ID("{A3B1C704-1A67-4319-B81A-40690E984C2B}");
            public static readonly ID TeamProjectRepository = new ID("{26591FEA-69ED-4791-AF00-56BCD3BD062B}");
            public static readonly ID TeamProjectDescription = new ID("{09EEBF3A-C99D-49DF-96BA-BDA556A9664D}");
        }
    }
    public struct Winner
    {
        public struct Folder
        {
            public static readonly ID WinnerFolder = new ID("{932E1EA0-DB8D-4371-B42B-F820F4CADCE2}");
            public static readonly ID Winner = new ID("{91A9B3A5-9CED-4BF5-AB40-F79C075D0817}");
        }
        public struct Fields
        {
            public static readonly ID WinnerTopic = new ID("{DF5064D8-A8E3-404D-83B8-11DB2609F194}");
            public static readonly ID WinnerTeam = new ID("{E9F30BA2-CB1C-4347-B97F-C3ED53C3A72A}");
            public static readonly ID WinnerPhoto = new ID("{8324B302-38E3-4059-B0C1-7095CC38BDD6}");
        }
    }
        public struct Topic
        {
            public struct Enum
            {
                public static readonly ID EnumTopic = new ID("{455A3E98-A627-4B40-8035-E683A0331AC7}");
            }
        }
  }
}