using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBuildingApi.Models
{
    public class PushVisitorDataReq
    {
        public string VisitName{ get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public string CellNo { get; set; }
        public string CarNo { get; set; }
        public string RegisteredTime { get; set; }
        public string ImageUrl { get; set; }

    }
}
