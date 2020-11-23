using EstimationApp.Utilities;
using ModelsLibrary.Enums;
using ModelsLibrary.Models;
using System.Windows.Input;

namespace EstimationApp.ViewModels
{
    public class EstimationScreenViewModel : ViewModelBase
    {
        private double? totalPrice;
        public double? GoldPrice { get; set; }
        public double? Weight { get; set; }
        public double? TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                NotifyPropertyChanged("TotalPrice");
            }
        }


        private DiscountStrategy discountStrategy;
        private User loggedInUser;

        public bool IsPriviledgedUser
        {
            get
            {
                return loggedInUser.UserType == UserTypeEnum.PrivilegedUser;
            }
        }
        public double Discount
        {
            get
            {
                return discountStrategy.discountPercentage;
            }
            set
            {

                discountStrategy.discountPercentage = value;

            }
        }

        public ICommand PrintCommand { get; set; }
        public ICommand CalculateTotalCommand { get; set; }
        public EstimationScreenViewModel(DiscountStrategy discountStrategy, User loggedInUser)
        {
            this.discountStrategy = discountStrategy;
            this.loggedInUser = loggedInUser;
            PrintCommand = new RelayCommand(Print, CanPrint);
            CalculateTotalCommand = new RelayCommand(CalculateTotal, CanCalculate);
        }

        private bool CanCalculate(object arg)
        {
            return GoldPrice.HasValue && Weight.HasValue && (!IsPriviledgedUser || (Discount > 0 && Discount < 100));
        }

        private void CalculateTotal(object obj)
        {
            var priceBeforeDiscount = GoldPrice * Weight;
            TotalPrice = priceBeforeDiscount.Value - discountStrategy.CalculateDiscount(priceBeforeDiscount.Value);
        }

        private bool CanPrint(object arg)
        {
            return TotalPrice.HasValue;
        }

        private void Print(object obj)
        {
            var printStrategy = PrintHelper.GetPrintStrategy((string)obj);
            printStrategy.Print("The total price is: " + TotalPrice.ToString());
        }
    }
}
