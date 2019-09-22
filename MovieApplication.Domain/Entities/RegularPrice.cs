using MovieApplication.Common.Enum;

namespace MovieApplication.Application.Entities
{
    public class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return (int)MovieTypeEnum.Regular;
        }
        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }

    }
}
