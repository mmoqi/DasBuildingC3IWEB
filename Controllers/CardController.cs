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
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            ResultCls cls = new ResultCls();
            string json = "";
            return Content(json);
        }

        /// <summary>
        /// 获取该用户的已分配卡和所有未分配卡
        /// </summary>
        /// <returns></returns>
        public ActionResult getEmpCardInfo(int empid, int currentPage, int pagesize)
        {

            ResultCls cls = new ResultCls();
            var db = new yida20171209NewEntities();
            List<DasBuilding_Com_CardInfo> cardInfoListResult = new List<DasBuilding_Com_CardInfo>();

            List<DasBuilding_Com_CardInfo> cardInfoList = new List<DasBuilding_Com_CardInfo>();
            //如果关联查询
            cardInfoList = db.DasBuilding_Com_CardInfo.Where(t => t.CardIsUse == 0).ToList();
            //cardInfoListResult.AddRange(cardInfoList);
            //cardInfoList = db.DasBuilding_Com_CardInfo.Where(t => t.CardIsUse == 0).ToList();

            var res = from a in db.DasBuilding_Com_CardInfo
                      join b in db.DasBuilding_Com_EmpCard
                      on a.CardID equals b.CardID
                      where b.EmpID== empid
                      select a ;
            cardInfoListResult=res.ToList();
            cardInfoListResult.AddRange(cardInfoList);
            
            cls.status = 0;
            cls.message = JsonConvert.SerializeObject(cardInfoListResult);
            string json = JsonConvert.SerializeObject(cls); 
            return Content(json);
        }

        /// <summary>
        /// 分配卡片
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public ActionResult AllotCard(int cardid, int empid)
        {
            ResultCls cls = new ResultCls();
            var db = new yida20171209NewEntities();            
            DasBuilding_Com_CardInfo cardinfo = db.DasBuilding_Com_CardInfo.Where(t => t.CardID == cardid).FirstOrDefault();
            DasBuilding_Com_EmpCard empcard = new DasBuilding_Com_EmpCard();
            empcard.CardID = cardid;
            empcard.EmpID = empid;
            empcard.CardStatusID = 20;            
            empcard.CardSegID =(int) cardinfo.CardSegID;
            empcard.CardDispNo = cardinfo.CardDispNo;
            empcard.CardStatusChgDay = DateTime.Now;
            db.DasBuilding_Com_EmpCard.Add(empcard);

            cardinfo.CardIsUse = 1;

            db.SaveChanges();

            
          
            cls.status = 0;
            cls.message = JsonConvert.SerializeObject(null);
            string json = JsonConvert.SerializeObject(cls);
            return Content(json);
        }


        /// <summary>
        /// 取消分配卡片
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public ActionResult CancellAllotCard(int cardid,int empid)
        {
            ResultCls cls = new ResultCls();
            var db = new yida20171209NewEntities();

            DasBuilding_Com_EmpCard empcard = db.DasBuilding_Com_EmpCard.Where(t => (t.EmpID == empid) && (t.CardID == cardid)).FirstOrDefault();
            DasBuilding_Com_CardInfo cardinfo = db.DasBuilding_Com_CardInfo.Where(t => t.CardID == cardid).FirstOrDefault();
            db.DasBuilding_Com_EmpCard.Remove(empcard);

            cardinfo.CardIsUse = 0;
            db.SaveChanges();
            cls.status = 0;
            cls.message = JsonConvert.SerializeObject(null);
            string json = JsonConvert.SerializeObject(cls); ;
            return Content(json);
        }

        /// <summary>
        /// 生成卡片
        /// </summary>
        /// <param name="count"></param>
        /// <param name="CardSegID"></param>
        /// <param name="cardtypeid"></param>
        /// <returns></returns>
        public ActionResult GenerateCard(int count, int CardSegID, int cardtypeid)
        {
            ResultCls cls = new ResultCls();
            var db = new yida20171209NewEntities();

            db.DasBuilding_up_AutoMngCardID(count,CardSegID,cardtypeid);
            db.SaveChanges();

            cls.status = 0;
            cls.message = JsonConvert.SerializeObject(null);
            string json = JsonConvert.SerializeObject(cls); ;
            return Content(json);
        }

        /// <summary>
        /// 查询所有卡片信息
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult GetAllCardInfo(int currentPage, int pagesize)
        {
            ResultCls cls = new ResultCls();
            var db = new yida20171209NewEntities();

            

            List<DasBuilding_Com_CardInfo> cardInfoList = new List<DasBuilding_Com_CardInfo>();
            cardInfoList=db.DasBuilding_Com_CardInfo.OrderByDescending(t=>t.CardID).Skip((currentPage - 1)* pagesize).Take(pagesize).ToList();

            ResultTabelList<DasBuilding_Com_CardInfo> result = new ResultTabelList<DasBuilding_Com_CardInfo>();

            result.total = db.DasBuilding_Com_CardInfo.Count();
            result.objList = cardInfoList;

            cls.status = 0;
            cls.message = JsonConvert.SerializeObject(result);

            string json = JsonConvert.SerializeObject(cls); ;
            return Content(json);
        }
    }
}