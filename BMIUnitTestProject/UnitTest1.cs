using Microsoft.VisualStudio.TestTools.UnitTesting;

using BMICalculator;
using System;

namespace BMIUnitTestProject
{
    [TestClass]
    public class UnitTest1

    {
   


        [TestMethod]
        public void BMICategory_SeniorObese_ReturnsObeseCategory()
        {
            // Arrange
            var bmi = new BMI
            {
                Age = 70,
                WeightStones = 16,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 6
            };

            // Act
            var category = bmi.BMICategory;


            // Assert
            Assert.AreEqual(BMICategory.Obese, category, "Senior BMI Category calculation is incorrect");
        }
        [TestMethod]
        public void BMICategory_AdultNormalBMI_ReturnsNormalCategory()
        {
            // Arrange
            var bmi = new BMI
            {
                Age = 30,
                WeightStones = 10,
                WeightPounds = 5,
                HeightFeet = 5,
                HeightInches = 9
            };

            // Act
            var category = bmi.BMICategory;

            // Assert
            Assert.AreEqual(BMICategory.Normal, category, "BMI Category calculation is incorrect");
        }


        [TestMethod]
        public void BMICategory_AdultOverweight_ReturnsObeseCategory()
        {
            // Arrange
            var bmi = new BMI
            {
                Age = 40,
                WeightStones = 15,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 9
            };

            // Act
            var category = bmi.BMICategory;

            // Assert
            Assert.AreEqual(BMICategory.Obese, category, "Adult Overweight BMI Category calculation is incorrect");
        }
        [TestMethod]
        public void BMICategory_ChildObese_ReturnsObeseCategory()
        {
            var bmi = new BMI
            {
                Age = 12,
                WeightStones = 10,
                WeightPounds = 0,
                HeightFeet = 4,
                HeightInches = 8
            };

            var category = bmi.BMICategory;

            Assert.AreEqual(BMICategory.Obese, category, "Child BMI Category calculation is incorrect");
        }


        [TestMethod]
        public void BMICategory_ChildUnderweight_ReturnsUnderweightCategory()
        {
            // Arrange
            var bmi = new BMI
            {
                Age = 10,
                WeightStones = 3,
                WeightPounds = 0,
                HeightFeet = 4,
                HeightInches = 5
            };

            // Act
            var category = bmi.BMICategory;

            // Assert
            Assert.AreEqual(BMICategory.Underweight, category, "Child BMI Category calculation is incorrect");
        }

    


        [TestMethod]
        public void TestMethod1()
        {
            BMI bmi = new BMI() { WeightStones = 12, WeightPounds = 0, HeightFeet = 5, HeightInches = 10, Age=12 };
            Assert.AreEqual(bmi.BMICategory, BMICategory.Overweight);
        }

        [TestMethod]
        public void TestMethod2()

        {
            BMI bmi = new BMI() { WeightStones = 15, WeightPounds = 0, HeightFeet = 5, HeightInches = 10, Age = 29 };
            Assert.AreEqual(bmi.BMICategory, BMICategory.Obese);
        }

    }
}
    
