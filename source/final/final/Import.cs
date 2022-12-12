using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Import
    {

        public Import(string accountantId, string goodsId, string goodsUnit, int quantity, DateTime importDate)
        {
            AccountantId = accountantId;
            GoodsId = goodsId;
            GoodsUnit = goodsUnit;
            Quantity = quantity;
            ImportDate = importDate;
        }

        public string AccountantId { set; get; }
        public string GoodsId { set; get; }
        public string GoodsUnit { set; get; }
        public int Quantity { set; get; }
        public DateTime ImportDate { set; get; }
    }
}
