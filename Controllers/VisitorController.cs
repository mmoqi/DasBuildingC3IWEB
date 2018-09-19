using DasBuildingApi.Models;
using DasBuildingWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DasBuildingWeb.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visistor
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult getAllVisitor(int pageSize, int pageNumber, string company,string name)
        {

            //ResultCls cls = new ResultCls();
            //var db = new yida20171209NewEntities();
            //List<DasBuilding_Visitor> visitors = new List<DasBuilding_Visitor>();
            //int allCount = 0;
            //string sql = "select id,VistName,VistCompany,VistTel,CarNo,isAuthen,isComing,faceImgUrl from DasBuilding_Visitor where 1=1 ";
            //if (company !="" && company!=null)
            //{
            //    sql += "and vistcompany like '%" + company + "%'";
            //}

            //if (name != "" && name != null)
            //{
            //    sql += "and vistname like '%" + name + "%'";
            //}


            //////visitors = db.DasBuilding_Visitor.SqlQuery(sql).OrderByDescending(u=>u.id).Skip((pageNumber - 1)* pageSize).Take(pageSize)Select(s => new
            ////{
            ////    s.id,
            ////    s.VistName,
            ////    s.VistCompany,
            ////    s.VistTel,
            ////    s.CarNo,
            ////    s.isAuthen,
            ////    s.isComing,
            ////    s.faceImgUrl
            ////}).ToList();
            //var result = db.Database.SqlQuery<DasBuilding_visitor_show>(sql).OrderByDescending(u => u.id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            ////visitors = db.DasBuilding_Visitor.SqlQuery(sql).OrderByDescending(u => u.id).Skip((offset)).Take(limit).ToList();
            //allCount = db.DasBuilding_Visitor.Count();
            //cls.status = 0;
            //cls.message = JsonConvert.SerializeObject(visitors);

            //string returenStr = JsonConvert.SerializeObject(result);

            //String json = "{\"total\":" + allCount + ",\"rows\":" + returenStr + "}";
            //return Content(json);         
            return Content("");
        }

    }
}