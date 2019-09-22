namespace MovieApplication.Application.Entities
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);

        public int GetFrequentRenterPoint(int daysRented)
        {
            return 1;
        }
    }
}
