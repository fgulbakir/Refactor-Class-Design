using MovieApplication.Common.BaseTypes;
using MovieApplication.Common.Enum;
using System;

namespace MovieApplication.Application.Entities
{
    public class Movie : BaseIntEntity
    {
        private string _title;
        private int _priceCode;
        private Price _price;
        public Movie(string title, int priceCode)
        {
            _title = title;
            PriceCode = priceCode;
        }

        public MovieTypeEnum MovieType { get; set; }

        public string Title
        {
            get { return _title; }

        }

        public int PriceCode
        {
            get { return _priceCode; }
            set
            {
                switch (_priceCode)
                {

                    case (int)MovieTypeEnum.Regular:
                          
                        _priceCode = new RegularPrice().GetPriceCode();
                        break;
                    case (int)MovieTypeEnum.Children:
                        _priceCode = new ChildrenPrice().GetPriceCode();
                        break;
                    case (int)MovieTypeEnum.NewRelease:
                        _priceCode = new NewReleasesPrice().GetPriceCode();
                        break;

                    default:
                       throw new ArgumentException("Incorrect PriceCode!");
                }
              


            }
        }
        public int GetFrequentRenterPoint(int daysRented)
        {

            return _price.GetFrequentRenterPoint(daysRented);

        }
        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);


        }

    }
}
