using Microsoft.VisualStudio.TestTools.UnitTesting;

using BMICalculator;

namespace BMIUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
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
