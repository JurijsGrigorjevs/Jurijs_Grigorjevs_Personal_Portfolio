using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurance.Models
{
    public class QuoteCalculator
    {
        public static decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50m;

            // Calculate age
            int currentYear = DateTime.Now.Year;
            int age = currentYear - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Now.AddYears(-age))
                age--;

            // Age-based quote adjustments
            if (age <= 18)
            {
                quote += 100m;
            }
            else if (age >= 19 && age <= 25)
            {
                quote += 50m;
            }
            else
            {
                quote += 25m;
            }

            // Car year adjustments
            if (insuree.CarYear < 2000)
            {
                quote += 25m;
            }
            else if (insuree.CarYear > 2015)
            {
                quote += 25m;
            }

            // Car make and model adjustments
            if (insuree.CarMake == "Porsche")
            {
                quote += 25m;
                if (insuree.CarModel == "911 Carrera")
                {
                    quote += 25m;
                }
            }

            // Speeding tickets adjustment
            quote += 10m * insuree.SpeedingTickets;

            // DUI adjustment
            if (insuree.DUI)
            {
                quote *= 1.25M;
            }

            // Coverage type adjustment
            if (insuree.CoverageType)
            {
                quote *= 1.5M;
            }

            return quote;
        }
    }
}