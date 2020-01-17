using B4.EE.VanLookManu.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace B4.EE.VanLookManu.Domain.Services.Validator
{
    public class UserValidator
    {
        public List<ValidationResult> ValidatorUser(User user)
        {
            int number = 0;
            List<ValidationResult> results = new List<ValidationResult>();
            if (IsStringEmpty(user.Username))
            {
                results.Add(new ValidationResult("username is empty"));
            }
            if (user.Activity == null)
            {
                results.Add(new ValidationResult("activity is" +
                    "" +
                    " empty"));
            }
            if (IsStringEmpty(user.Id.ToString()))
            {

                results.Add(new ValidationResult("id is empty"));
            }
            bool tryParseSucces = int.TryParse(user.Id.ToString(), out number);
            if (tryParseSucces)
            {
                results.Add(new ValidationResult("id is not a valid type"));
            }
            if (IsStringEmpty(user.Status.ToString()))
            {
                results.Add(new ValidationResult("status is empty"));
            }
            if (IsStringEmpty(user.Discriminator))
            {
                results.Add(new ValidationResult("discriminator is empty"));
            }
            if (IsStringEmpty(user.CreatedAt.ToString()) || user.CreatedAt == new DateTimeOffset())
            {
                results.Add(new ValidationResult("CreatedAt is empty"));
            }
            return results;
        }

        private bool IsStringEmpty(string objectString)
        {
            if (string.IsNullOrEmpty(objectString))
            {
                return true;
            }
            return false;
        }

    }
}
