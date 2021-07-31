using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Engines;
using PromotionEngine.Models;
using PromotionEngine.Testing.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine//.Testing
{
    [TestClass]
    public class PromotionEngineUnitTests
    {
        [TestMethod]
        public void Scenario_A_TestMethod()
        {
            List<SkuPrice> skuPrices = new List<SkuPrice>();
            List<Promotion> promotions = new List<Promotion>();

            TestBuild testBuild = new TestBuild();
            testBuild.BuildTestData(skuPrices, promotions);
            var checkoutItems = testBuild.BuildScenario_A();

            var engine = new PromoEngine();
            var result = engine.GetPriceWithPromotion(checkoutItems, promotions, skuPrices);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Scenario_B_TestMethod()
        {
            List<SkuPrice> skuPrices = new List<SkuPrice>();
            List<Promotion> promotions = new List<Promotion>();

            TestBuild testBuild = new TestBuild();
            testBuild.BuildTestData(skuPrices, promotions);
            var checkoutItems = testBuild.BuildScenario_B();

            var engine = new PromoEngine();
            var result = engine.GetPriceWithPromotion(checkoutItems, promotions, skuPrices);
                        
            Assert.AreEqual(370, result);
        }
    }
}
