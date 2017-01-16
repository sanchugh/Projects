using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementLib
{
    public abstract class Stock
    {
        protected decimal _stockWeight;
        public abstract StockType StockType { get; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal MarketValue => Price * Quantity;
        public abstract decimal TransactionCost { get; }
        //  public decimal StockWeight { get { return decimal.Round(_stockWeight,2); } }
        public string StockWeight { get { return _stockWeight.ToString("N3"); }}
        //protected abstract decimal Tolerance { get; }
        //protected bool ToleranceBreached => MarketValue < 0 || TransactionCost > Tolerance;
        public void AdjustStockWeight(decimal totalMarketValue)
        {
            _stockWeight = totalMarketValue == 0 ? 0 : (MarketValue * 100) / totalMarketValue;
        }
        public decimal GetStockWeight()
        {
            return _stockWeight;
        }
        protected Stock(string name, decimal price, decimal quantity)
        {
            StockName = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
