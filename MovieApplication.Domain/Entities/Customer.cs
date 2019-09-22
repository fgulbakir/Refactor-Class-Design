using MovieApplication.Common.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApplication.Application.Entities
{
    public class Customer : BaseIntEntity
    {
        private string _fullName;
        private List<Rental> _rentals;

        public string FullName
        {
            get => _fullName;

        }

        public Customer(string fullName)
        {
            _fullName = fullName;
            _rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);

        }

        public string Statement()
        {
            var rentals = _rentals.ToList();
            string result = "Rental Record for " + FullName + "\n";
            if (rentals.Any())
            {
                foreach (var rental in rentals)
                {
                    result += "\t" + rental.Movie.Title + "\t" + Convert.ToString(rental.Movie.GetCharge(rental.DayRent));
                }

                result = result + ("Amount owed is " + Convert.ToString(GetTotalCharge()));
                result += "You earned " + Convert.ToString(GetTotalFrequentRentelPoint()) + "frequent rental points ";
            }

            return result;
        }

        private double AmountFor(Rental aRental)
        {
            return aRental.Movie.GetCharge(aRental.DayRent);
        }

        private double GetTotalCharge()
        {
            double resut = 0;
            if (_rentals.Any())
            {

                foreach (var rental in _rentals)
                {
                    resut += rental.Movie.GetCharge(rental.DayRent);
                }
            }

            return resut;
        }

        private int GetTotalFrequentRentelPoint()
        {
            int result = 0;
            if (_rentals.Any())
            {
                foreach (var rental in _rentals)
                {
                    result += rental.GetFrequentRenterPoint();
                }
            }

            return result;
        }


        public string HtmlStatement()
        {
            var rentals = _rentals.ToList();
            string result = "<H1>Rentals for <EM>" + FullName + "</EM></ H1><P>\n";
            if (_rentals.Any())
            {
                foreach (var rental in rentals)
                {
                    result += rental.Movie.Title + ": " + Convert.ToString(rental.Movie.GetCharge(rental.DayRent)) + "<BR>\n";
                }
            }

            result += "<P>You owe <EM>" + Convert.ToString(GetTotalCharge()) + "</EM><P>\n";
            result += "On this rental you earned <EM>" + Convert.ToString(GetTotalFrequentRentelPoint()) +
                      "</EM> frequent renter points<P>";
            return result;
        }

    }
}
