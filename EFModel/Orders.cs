//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public System.Guid ID { get; set; }
        public string sOrderNo { get; set; }
        public string sGoodName { get; set; }
        public string sGoodNo { get; set; }
        public string sGoodsPicture { get; set; }
        public string sGoodsInfo { get; set; }
        public int iGoodsCount { get; set; }
        public decimal dPrices { get; set; }
        public decimal dTotalPrices { get; set; }
        public string sActivity { get; set; }
        public string sOrderRemark { get; set; }
        public string sReceiver { get; set; }
        public string sAddress { get; set; }
        public int iState { get; set; }
        public System.DateTime dBookTime { get; set; }
        public System.DateTime dPayTime { get; set; }
        public string sPhone { get; set; }
        public bool bIsDeleted { get; set; }
        public bool bIsTip { get; set; }
        public System.DateTime dTipTime { get; set; }
        public decimal dSinglePrices { get; set; }
        public string sWuliuCompany { get; set; }
        public string sWuliuNumber { get; set; }
    }
}
