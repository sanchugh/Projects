using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementLib
{
    public interface IStockFactory
    {
        Stock CreateStock(StockType stockType, string name, decimal price, decimal quantity);
    }
}
