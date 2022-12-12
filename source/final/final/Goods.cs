using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Goods
    {
        public Goods(string goodsId, string goodsName, string goodsUnit, decimal goodsPrice, string manuID)
        {
            GoodsId = goodsId;
            GoodsName = goodsName;
            GoodsUnit = goodsUnit;
            GoodsPrice = goodsPrice;
            ManuId = manuID;
        }

        public string GoodsId { set; get; }
        public string GoodsName { set; get; }
        public string GoodsUnit { set; get; }
        public decimal GoodsPrice { set; get; }
        public string ManuId { set; get; }
    }
}
