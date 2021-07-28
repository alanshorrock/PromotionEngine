using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public List<Item> PromotionItems { get; set; }
        public int PromotionPrice { get; set; }

        public Promotion(int id, List<Item> promotionItems, int promotionPrice)
        {
            Id = id;
            PromotionItems = promotionItems;
            PromotionPrice = promotionPrice;
        }

    }
}
