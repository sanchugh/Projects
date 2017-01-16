using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementLib
{
    public class StockFactory : IStockFactory
    {
        public Stock CreateStock(StockType stockType, string name, decimal price, decimal quantity)
        {
            switch (stockType)
            {
                case StockType.Bond:
                    return new Bond(name, price, quantity);
                case StockType.Equity:
                    return new Equity(name, price, quantity);
                default:
                    throw new ArgumentException("Invalid Stock Type !");
            }
        }
    }
}
