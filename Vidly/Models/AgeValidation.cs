using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class AgeValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;
           
            if (customer.MembershipTypeId == MembershipType.UNKNOWN || customer.MembershipTypeId == MembershipType.PAY_AS_YOU_GO)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Date of Birth is required");

            var customerAge = DateTime.Today.Year - customer.Birthdate.Value.Year;
           
            if (customerAge >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("You must be above 18 years to select a memebership type other than pay as you go");
        }
    }
   
}