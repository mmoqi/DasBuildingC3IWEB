using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBuildingApi.Models
{
    public class VisitorReq
    {

        public string VistName { get; set; }
        public string VisitTime { get; set; }
        public string VistFloor { get; set; }
        public string VsitedName { get; set; }
        public string VsitedTel { get; set; }
        public string VsitedCompany { get; set; }

        public Image VsitImg { get; set; }

        public FileStream file { get; set; }
    }
}
