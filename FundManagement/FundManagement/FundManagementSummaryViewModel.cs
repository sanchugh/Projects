using FundManagementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagement
{
    public partial class FundManagementViewModel
    {
        // Summary panel 
        public decimal TotalEquityNumber
        {
            get { return _stockData.Count(s => s.StockType == StockType.Equity); }
        }
        public decimal TotalEquityMarketValue
        {
            get { return _stockData.Where(s => s.StockType == StockType.Equity).Sum(s => s.MarketValue); }
        }
        public decimal TotalEquityStockWeight
        {
            get { return _stockData.Where(s => s.StockType == StockType.Equity).Sum(s => s.GetStockWeight()); }
        }

        public decimal TotalBondNumber
        {
            get { return _stockData.Count(s => s.StockType == StockType.Bond); }
        }
        public decimal TotalBondMarketValue
        {
            get { return _stockData.Where(s => s.StockType == StockType.Bond).Sum(s => s.MarketValue); }
        }
        public decimal TotalBondStockWeight
        {
            get { return _stockData.Where(s => s.StockType == StockType.Bond).Sum(s => s.GetStockWeight()); }
        }

        public decimal TotalFundNumber
        {
            get { return _stockData.Count(); }
        }
        public decimal TotalFundMarketValue
        {
            get { return _stockData.Sum(s => s.MarketValue); }
        }
        public decimal TotalFundStockWeight
        {
            get { return _stockData.Sum(s => s.GetStockWeight()); }
        }

        public void RefreshTotalProperties()
        {
            OnPropertyChanged(nameof(TotalEquityNumber));
            OnPropertyChanged(nameof(TotalEquityMarketValue));
            OnPropertyChanged(nameof(TotalEquityStockWeight));

            OnPropertyChanged(nameof(TotalBondNumber));
            OnPropertyChanged(nameof(TotalBondMarketValue));
            OnPropertyChanged(nameof(TotalBondStockWeight));

            OnPropertyChanged(nameof(TotalFundNumber));
            OnPropertyChanged(nameof(TotalFundMarketValue));
            OnPropertyChanged(nameof(TotalFundStockWeight));
        }
    }
}
