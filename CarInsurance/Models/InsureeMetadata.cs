using System;
using System.ComponentModel.DataAnnotations;


namespace CarInsurance.Models
{
    public class InsureeMetadata
    {

            // Required field with a display name of "First Name".
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            // Required field with a display name of "Last Name".
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            // Required field, validated as an email address, with a display name of "Email Address".
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string EmailAddress { get; set; }

            // Required field with a display name of "Date of Birth" and specified as a Date type.
            [Required]
            [Display(Name = "Date of Birth")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            // Required field, with a specified range and display name of "Car Year".
            [Required]
            [Range(1886, 2025, ErrorMessage = "Please enter a valid car year.")]
            [Display(Name = "Car Year")]
            public int CarYear { get; set; }

            // Required field with a display name of "Car Make".
            [Required]
            [Display(Name = "Car Make")]
            public string CarMake { get; set; }

            // Required field with a display name of "Car Model".
            [Required]
            [Display(Name = "Car Model")]
            public string CarModel { get; set; }

            // Required field indicating whether the person has a DUI (Driving Under the Influence).
            [Required]
            public bool DUI { get; set; }


            // Required field with a specified range and display name of "Speeding Tickets".
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of tickets.")]
            [Display(Name = "Speeding Tickets")]
            public int SpeedingTickets { get; set; }

            // Required field with a display name of "Coverage Type" indicating whether the coverage is comprehensive or basic.
            [Required]
            [Display(Name = "Coverage Type")]
            public bool CoverageType { get; set; }

            // Field with a display name of "Insurance Quote" and specified as a currency type.
            [Display(Name = "Insurance Quote")]
            [DataType(DataType.Currency)]
            public decimal Quote { get; set; }
        }
    }


