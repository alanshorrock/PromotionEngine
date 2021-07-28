using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemType { get; set; }
        public int InitialQuantity { get; set; }
        public int EffectiveQuantity { get; set; }

        public Item(string id, string type, int quantity)
        {
            ItemId = id;
            ItemType = type;
            InitialQuantity = quantity;
            EffectiveQuantity = quantity;
        }

        public Item(string id, int quantity)
        {
            ItemId = id;
            InitialQuantity = quantity;
            EffectiveQuantity = quantity;
        }
               

        public void subtractEffectiveQuantity(int quantityChange)
        {
            EffectiveQuantity = EffectiveQuantity - quantityChange;
        }
    }
}
