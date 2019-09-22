using MovieApplication.Common.Enum;

namespace MovieApplication.Application.Entities
{
    public class ChildrenPrice : Price
    {
        public override int GetPriceCode()
        {
            return (int)MovieTypeEnum.Children;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}
