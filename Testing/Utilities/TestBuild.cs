using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Testing.Utilities
{
    public class TestBuild
    {
        public void BuildTestData(List<SkuPrice> skuPrices, List<Promotion> promotions)
        {
            skuPrices.Clear();
            skuPrices.Add(new SkuPrice("A", 50));
            skuPrices.Add(new SkuPrice("B", 30));
            skuPrices.Add(new SkuPrice("C", 20));
            skuPrices.Add(new SkuPrice("D", 15));

            promotions.Clear();
            var currentPromotionItems_1 = new List<Item>
            {
                new Item("A", "SKU", 3)
            };
            var currentPromotion_1 = new Promotion(1, currentPromotionItems_1, 130);
            promotions.Add(currentPromotion_1);

            var currentPromotionItems_2 = new List<Item>
            {
                new Item("B", "SKU", 2)
            };
            var currentPromotion_2 = new Promotion(2, currentPromotionItems_2, 45);
            promotions.Add(currentPromotion_2);

            //var currentPromotionItems_3 = new List<Item>
            //{
            //    new Item("C", "SKU", 1),
            //    new Item("D", "SKU", 1)
            //};
            //var currentPromotion_3 = new Promotion(3, currentPromotionItems_3, 30);
            //promotions.Add(currentPromotion_3);
        }

        public List<Item> BuildScenario_A()
        {
            var items = new List<Item>
            {
                new Item("A", "SKU", 1),
                new Item("B", "SKU", 1),
                new Item("C", "SKU", 1)
            };

            return items;
        }

        public List<Item> BuildScenario_B()
        {
            var items = new List<Item>
            {
                new Item("A", "SKU", 5),
                new Item("B", "SKU", 5),
                new Item("C", "SKU", 1)
            };

            return items;
        }
    }
}
