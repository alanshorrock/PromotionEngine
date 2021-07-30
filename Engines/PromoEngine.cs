using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var matchingItems = new List<Item>();
                if (promotion.PromotionItems.Count > 0)
                {
                    int promoQuantity = 0;
                    int itemQuantity = 0;
                    int i = 0;
                    Item currentItem = null;
                    while (i < items.Count)
                    {
                        currentItem = items[i];
                        Item matchingItem = promotion.PromotionItems.Find(pi => pi.ItemId == currentItem.ItemId);
                        if (matchingItem != null)
                        {
                            matchingItems.Add(matchingItem);
                            //if (matchingItem.EffectiveQuantity <= currentItem.EffectiveQuantity)
                            //{
                            //    promoQuantity = currentItem.EffectiveQuantity / matchingItem.EffectiveQuantity;
                            //    itemQuantity = currentItem.EffectiveQuantity % matchingItem.EffectiveQuantity;
                            //    if (promoQuantity > 0)
                            //    {
                            //        Item newItem = new Item(currentItem.ItemId, currentItem.ItemType, currentItem.InitialQuantity);
                            //        Item promoItem = new Item(promotion.Id.ToString(), "Promotion", promoQuantity);
                            //        newItem.EffectiveQuantity = itemQuantity;
                            //        items.RemoveAt(i);
                            //        items.Insert(i, newItem);
                            //        items.Add(promoItem);
                            //        break;
                            //    }
                            //}                            
                        }
                        i++;
                    }
                    var matches = matchingItems
                        .Join(items, mi => mi.ItemId, i => i.ItemId,
                        (mi, i) => new { ItemId = i.ItemId, ItemQuantity = i.EffectiveQuantity % mi.EffectiveQuantity, PromoQuantity = i.EffectiveQuantity / mi.EffectiveQuantity })
                        .Where(j => j.PromoQuantity > 0)
                        .ToList();

                    i = 0;
                    while (i < items.Count)
                    {
                        currentItem = items[i];
                        var match = matches.Find(m => m.ItemId == currentItem.ItemId);
                        if (match != null)
                        {
                            Item newItem = new Item(currentItem.ItemId, currentItem.ItemType, currentItem.InitialQuantity);
                            newItem.EffectiveQuantity = match.ItemQuantity;
                            Item promoItem = new Item(promotion.Id.ToString(), "Promotion", promoQuantity);
                            items.RemoveAt(i);
                            items.Insert(i, newItem);
                            items.Add(promoItem);
                        }
                    }
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
