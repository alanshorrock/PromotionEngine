using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Engines
{
    public class PromoEngine
    {
        public int GetPriceWithPromotion(List<Item> items, List<Promotion> promotions, List<SkuPrice> prices)
        {
            // Look for required promotion in items, use the first one found
            foreach(Promotion promotion in promotions)
            {
                if (promotion.PromotionItems.Count > 0)
                {
                    int promoQuantity = 0;
                    int itemQuantity = 0;
                    int i = 0;
                    Item currentItem = null;
                    Item matchingItem = null;
                    while (i < items.Count)
                    {
                        currentItem = items[i];
                        matchingItem = promotion.PromotionItems.Find(pi => pi.ItemId == currentItem.ItemId);
                        if (matchingItem != null)
                        {
                            if (matchingItem.EffectiveQuantity <= currentItem.EffectiveQuantity)
                            {
                                promoQuantity = currentItem.EffectiveQuantity / matchingItem.EffectiveQuantity;
                                itemQuantity = currentItem.EffectiveQuantity % matchingItem.EffectiveQuantity;
                                if (promoQuantity > 0)
                                {
                                    Item newItem = new Item(currentItem.ItemId, currentItem.ItemType, currentItem.InitialQuantity);
                                    Item promoItem = new Item(promotion.Id.ToString(), "Promotion", promoQuantity);
                                    newItem.EffectiveQuantity = itemQuantity;
                                    items.RemoveAt(i);
                                    items.Insert(i, newItem);
                                    items.Add(promoItem);
                                    break;
                                }
                            }
                            
                        }
                        i++;
                    }
                    //if (promoQuantity > 0)
                    //{
                    //    break;
                    //}
                }
            }

            int totalPrice = 0;
            foreach (Item item in items)
            {
                totalPrice += item.EffectiveQuantity * GetItemPrice(item, promotions, prices); 
            }

            return totalPrice;
        }

        private int GetItemPrice(Item item, List<Promotion> promotions, List<SkuPrice> prices)
        {
            if (item.ItemType == "SKU")
            {
                SkuPrice sku = prices.Find(p => p.SkuId == item.ItemId);
                return sku.Price;
            }
            else if (item.ItemType == "Promotion")
            {
                Promotion promotion = promotions.Find(p => p.Id.ToString() == item.ItemId);
                return promotion.PromotionPrice;
            }
            else
            {
                return 0;
            }
              
        }
    }
}
