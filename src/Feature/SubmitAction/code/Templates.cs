using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Hackathon.Feature.RegisterTeam
{
    public struct Templates
    {

        public struct Team
        {
            public static readonly ID Id = new ID("{25D09680-58D4-4E81-8B44-C26E713F8171}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{C9325C96-70AA-48E3-9974-9DE87099A778}");
                public static readonly ID Description = new ID("{5BAF8ACB-EE08-4BB9-A568-BE472410A2BD}");
                public static readonly ID Logo = new ID("{19F1730F-1672-4B72-B583-FF7F8DAB1ED5}");
                public static readonly ID SubmissionDate = new ID("{343635C8-B0EF-4603-95D8-F5C9310FCE2F}");
                public static readonly ID VideoLink = new ID("{A3B1C704-1A67-4319-B81A-40690E984C2B}");
                public static readonly ID ProjectRepository = new ID("{26591FEA-69ED-4791-AF00-56BCD3BD062B}");
                public static readonly ID ProjectDescription = new ID("{09EEBF3A-C99D-49DF-96BA-BDA556A9664D}");
            }

        }

        public struct Person
        {
            public static readonly ID Id = new ID("{B3F46401-62EA-4FD9-A409-27BE21150A1F}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{8F95C9AB-3019-4091-9D0E-9F22DC31648D}");
                public static readonly ID Country = new ID("{5660AAA1-6EFE-41AF-B852-0E47870CA926}");
                public static readonly ID LinkedIn = new ID("{240337B8-1CFB-41AA-A0AD-6AB78A69F0F2}");
                public static readonly ID Facebook = new ID("{E7872B5E-03BF-4FB9-A55F-2A60F9047AB5}");
                public static readonly ID Instagram = new ID("{A8A0C020-FF3D-432D-9E85-AC7372EA248D}");
                public static readonly ID Twitter = new ID("{C9A4E3EB-2BB0-448C-8BCF-62A20917AE04}");
                public static readonly ID IsTeamLeader = new ID("{802E9150-466F-4213-BF6F-00F2814487B1}");
                public static readonly ID Photo = new ID("{13BD0F9A-36CD-4024-87E8-60EADF0361FA}");
            }

        }

    }
}