using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementLib
{
    public class Equity : Stock
    {
        public Equity(string name, decimal price, decimal quantity) : base(name, price, quantity)
        {
        }

        public override StockType StockType => StockType.Equity;
        //protected override decimal Tolerance => 200000;
        public override decimal TransactionCost => MarketValue * 0.005M;
    }
}
