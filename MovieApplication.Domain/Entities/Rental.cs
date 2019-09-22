using MovieApplication.Common.BaseTypes;

namespace MovieApplication.Application.Entities
{
    public class Rental : BaseIntEntity
    {
        private Movie _movie;
        private int _daysRented;
        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }


        public Movie Movie
        {
            get { return _movie; }

        }

        public int DayRent
        {
            get { return _daysRented; }

        }
        public int GetFrequentRenterPoint()
        {

            return _movie.GetFrequentRenterPoint(DayRent);

        }

    }
}
