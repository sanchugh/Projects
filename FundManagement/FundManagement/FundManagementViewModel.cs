using DevExpress.Mvvm;
using FundManagementLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagement
{
    public partial class FundManagementViewModel : ViewModel
    {
        public DelegateCommand<string> UpdateStocks { get; private set; }
        IStockFactory _factory;

        public FundManagementViewModel()
        {
            _factory = new StockFactory();
            StockTypes = GetStockTypes();
            StockData = new ObservableCollection<Stock>();
            BuildCommands();
        }

        private string _inputQuantity;
        public string InputQuantity
        {
            get { return _inputQuantity; }
            set {
                _inputQuantity = value;
                OnPropertyChanged();
            }
        }

        private string _inputPrice;
        public string InputPrice
        {
            get { return _inputPrice; }
            set { _inputPrice = value; OnPropertyChanged(); }
        }

        private StockType _selectedStockType;
        public StockType SelectedStockType
        {
            get { return _selectedStockType; }
            set { _selectedStockType = value; OnPropertyChanged(); }
        }
            private IList<StockType> _stockTypes;
        public IList<StockType> StockTypes
        {
            get { return _stockTypes; }
            set { _stockTypes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Stock> _stockData;

        public ObservableCollection<Stock> StockData
        {
            get { return _stockData; }
            set { _stockData = value; OnPropertyChanged(); }
        }

        public void BuildCommands()
        {
            UpdateStocks = new DelegateCommand<string>(x => Add(), x => CanExecute(x));
        }

        private void Add()
        {
            AddStock(SelectedStockType, Convert.ToDecimal(InputPrice), Convert.ToDecimal(InputQuantity));
        }

        public bool CanExecute(string str)
        {
            if (!String.IsNullOrEmpty(InputPrice) && !string.IsNullOrEmpty(InputQuantity))
            {
                decimal price;
                var priceResult = decimal.TryParse(InputPrice, out price);

                decimal quantity;
                var priceQuantity = decimal.TryParse(InputQuantity, out quantity);
                if (priceResult && priceQuantity && Convert.ToDecimal(InputPrice) != 0 && Convert.ToDecimal(InputQuantity) != 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void AddStock(StockType stocktype, decimal price, decimal quantity)
        {
            int index;
            if (stocktype == StockType.Bond)
            {
                index = _stockData.Where(s => s.StockType == StockType.Bond).Count() + 1;
            }
            else
            {
                index = _stockData.Where(s => s.StockType == StockType.Equity).Count() + 1;
            }

            var newStock = _factory.CreateStock(stocktype, stocktype.ToString() + index, price, quantity);

            _stockData.Add(newStock);

            foreach (var stock in _stockData) stock.AdjustStockWeight(TotalFundMarketValue);

            RefreshTotalProperties();
        }
        private IList<StockType> GetStockTypes()
        {
            // can be sourced from other sources for more generic implementation
             var stockTypes = new List<StockType>();
            stockTypes.Add(StockType.Bond);
            stockTypes.Add(StockType.Equity);

            return stockTypes;
        }
    }
}
