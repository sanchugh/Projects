using FundManagement;
using FundManagementLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementTest
{
    [TestClass]
    public class FundManagementViewModelTests
    {
        [TestMethod]
        public void AddBondAndNameTest()
        {
            var fundManagementVM = new FundManagementViewModel();

            fundManagementVM.AddStock(StockType.Bond, 100, 5000);
            fundManagementVM.AddStock(StockType.Bond, 200, 6000);
            fundManagementVM.AddStock(StockType.Bond, 300, 7000);

            var lastBond = fundManagementVM.StockData.LastOrDefault();

            Assert.AreEqual(lastBond.StockName, "Bond3");
            Assert.AreEqual(lastBond.Price, 300);
            Assert.AreEqual(lastBond.Quantity, 7000);
            Assert.AreEqual(lastBond.MarketValue, 300 * 7000);
        }
        [TestMethod]
        public void AddEquityAndNameTest()
        {
            var fundManagementVM = new FundManagementViewModel();

            fundManagementVM.AddStock(StockType.Equity, 150, 5000);
            fundManagementVM.AddStock(StockType.Equity, 250, 10000);

            var lastEquity = fundManagementVM.StockData.LastOrDefault();

            Assert.AreEqual(lastEquity.StockName, "Equity2");
            Assert.AreEqual(lastEquity.Price, 250);
            Assert.AreEqual(lastEquity.Quantity, 10000);
            Assert.AreEqual(lastEquity.MarketValue, 250 * 10000);
        }
        [TestMethod]
        public void TotalEquityNumberTest()
        {
            var fundManagementVM = InitializeVM();
            var expectedTotalEquityNumber = 2;

            Assert.AreEqual(expectedTotalEquityNumber, fundManagementVM.TotalEquityNumber);
        }
         [TestMethod]
        public void TotalEquityMarketValueTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalEquityMarketValue = 3250000M;

            Assert.AreEqual(expectedTotalEquityMarketValue, fundManagementVM.TotalEquityMarketValue);
        }
        [TestMethod]
        public void TotalEquityStockWeightTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalEquityStockWeight = 46.1M;

            Assert.AreEqual(expectedTotalEquityStockWeight, Math.Round(fundManagementVM.TotalEquityStockWeight,2));
        }
        [TestMethod]
        public void TotalBondNumberTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalBondNumber = 3;

            Assert.AreEqual(expectedTotalBondNumber, fundManagementVM.TotalBondNumber);
        }
        [TestMethod]
        public void TotalBondMarketValueTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalBondMarketValue = 3800000M;

            Assert.AreEqual(expectedTotalBondMarketValue, fundManagementVM.TotalBondMarketValue);

        }
        [TestMethod]
        public void TotalBondStockWeightTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalBondStockWeight = 53.9M;

            Assert.AreEqual(expectedTotalBondStockWeight, Math.Round(fundManagementVM.TotalBondStockWeight, 2));
        }
        [TestMethod]
        public void TotalFundNumberTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalFundNumber = 5;

            Assert.AreEqual(expectedTotalFundNumber, fundManagementVM.TotalFundNumber);
        }
        [TestMethod]
        public void TotalFundMarketValueTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalFundMarketValue = 7050000M;

            Assert.AreEqual(expectedTotalFundMarketValue, fundManagementVM.TotalFundMarketValue);

        }
        [TestMethod]
        public void TotalFundStockWeightTest()
        {
            var fundManagementVM = InitializeVM();

            var expectedTotalFundStockWeight = 100M;

            Assert.AreEqual(expectedTotalFundStockWeight, fundManagementVM.TotalFundStockWeight);
        }
        private FundManagementViewModel InitializeVM()
        {
            var fundManagementVM = new FundManagementViewModel();

            fundManagementVM.AddStock(StockType.Bond, 100, 5000);
            fundManagementVM.AddStock(StockType.Bond, 200, 6000);
            fundManagementVM.AddStock(StockType.Bond, 300, 7000);

            fundManagementVM.AddStock(StockType.Equity, 150, 5000);
            fundManagementVM.AddStock(StockType.Equity, 250, 10000);

            return fundManagementVM;
        }
    }
}
