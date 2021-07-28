using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class SkuPrice
    {
        public string SkuId { get; set; }
        public int Price { get; set; }

        public SkuPrice(string skuId, int price)
        {
            SkuId = skuId;
            Price = price;
        }
    }
}
