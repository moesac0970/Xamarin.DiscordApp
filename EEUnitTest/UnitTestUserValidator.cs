using B4.EE.VanLookManu.Domain.Services.Validator;
using EEUnitTest.Mock;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace EEUnitTest
{
    public class UnitTestUserValidator
    {

        UserValidator UserValidator;
        private RepoMockData MockData = new RepoMockData();


        [Fact]
        public void NotValidUser1FAtCreatedAt()
        {
            // Arange 
            UserValidator = new UserValidator();
            List<ValidationResult> result = new List<ValidationResult>();

            // Act 
            result = UserValidator.ValidatorUser(MockData.NotValidUser1FAtCreatedAt);

            // Assert
            Assert.True(result.Count == 1, "The number of validation errors is not 1");

        }
        [Fact]
        public void NotValidUser1FAtDiscriminator()
        {
            // Arange 
            UserValidator = new UserValidator();
            List<ValidationResult> result = new List<ValidationResult>();

            // Act 
            result = UserValidator.ValidatorUser(MockData.NotValidUser1FAtDiscriminator);

            // Assert
            Assert.True(result.Count == 1, "The number of validation errors is not 1");

        }
        [Fact]
        public void NotValidUser1FAtId()
        {
            // Arange 
            UserValidator = new UserValidator();
            List<ValidationResult> result = new List<ValidationResult>();

            // Act 
            result = UserValidator.ValidatorUser(MockData.NotValidUser1FAtId);

            // Assert
            Assert.True(result.Count == 1, "The number of validation errors is not 1");

        }
        [Fact]
        public void NotValidUser1FAtUName()
        {
            // Arange 
            UserValidator = new UserValidator();
            List<ValidationResult> result = new List<ValidationResult>();

            // Act 
            result = UserValidator.ValidatorUser(MockData.NotValidUser1FAtUName);

            // Assert
            Assert.True(result.Count == 1, "The number of validation errors is not 1");

        }



    }
}
