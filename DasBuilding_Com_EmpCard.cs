//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DasBuildingWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class DasBuilding_Com_EmpCard
    {
        public int EmpID { get; set; }
        public int CardID { get; set; }
        public string CardDispNo { get; set; }
        public int CardSegID { get; set; }
        public byte CardStatusID { get; set; }
        public Nullable<System.DateTime> CardStatusChgDay { get; set; }
        public Nullable<decimal> ActForegift { get; set; }
        public Nullable<decimal> DisForegift { get; set; }
        public Nullable<decimal> RtnForegift { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CardDueDay { get; set; }
        public string CardPWD { get; set; }
        public Nullable<bool> CanReleaseLose { get; set; }
        public Nullable<decimal> actcost { get; set; }
    }
}
