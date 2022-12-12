using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Order
    {
        public Order(string agentId, string goodsId, string goodsUnit, int quantity, DateTime orderDate, string chargeState, string deliveryState)
        {
            AgentId = agentId;
            GoodsId = goodsId;
            GoodsUnit = goodsUnit;
            Quantity = quantity;
            OrderDate = orderDate;
            this.chargeState = chargeState;
            this.deliveryState = deliveryState;
        }

        public string AgentId { set; get; }
        public string GoodsId { set; get; }
        public string GoodsUnit { set; get; }
        public int Quantity { set; get; }
        public DateTime OrderDate { set; get; }
        public string chargeState { set; get; }
        public string deliveryState { set; get; }

    }
}
