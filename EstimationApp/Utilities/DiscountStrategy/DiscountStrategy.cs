namespace EstimationApp.Utilities
{
    public abstract class DiscountStrategy
    {
        public double discountPercentage;
        public virtual double CalculateDiscount(double price)
        {
            return (discountPercentage / 100) * price;
        }
    }
}
