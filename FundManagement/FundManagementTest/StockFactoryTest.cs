using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManagementLib;

namespace FundManagementTest
{
    [TestClass]
    public class StockFactoryTest
    {
        [TestMethod]
        public void CreateBondTest()
        {
            var factory = new StockFactory();

            var stock = factory.CreateStock(StockType.Bond, "Equity1", 1500, 500);

            Assert.AreEqual(stock.Price, 1500);
            Assert.AreEqual(stock.Quantity, 500);
            Assert.AreEqual(stock.MarketValue, 1500*500);
            Assert.AreEqual(stock.MarketValue, 1500 * 500);
        }

        [TestMethod]
        public void CreateEquityTest()
        {
            var factory = new StockFactory();

            var stock = factory.CreateStock(StockType.Bond, "Equity1", 1500, 500);

            Assert.AreEqual(stock.Price, 1500);
            Assert.AreEqual(stock.Quantity, 500);
            Assert.AreEqual(stock.MarketValue, 1500 * 500);
            Assert.AreEqual(stock.MarketValue, 1500 * 500);


        }
    }
}
