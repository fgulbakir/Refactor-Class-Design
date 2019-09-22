using MovieApplication.Common.Enum;

namespace MovieApplication.Application.Entities
{
    public class NewReleasesPrice : Price
    {
        public override int GetPriceCode()
        {
            return (int)MovieTypeEnum.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public int GetFrequentRenterPoint(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
}
