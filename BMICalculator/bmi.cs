// model classes for BMI calculator
// GC

using System;
using System.ComponentModel.DataAnnotations;

namespace BMICalculator
{
    public enum BMICategory { Underweight, Normal, Overweight, Obese, NeedsAssessment };

    public class BMI
    {
        const double UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;               // Obese from 30 +

        // conversion factors from imperial to metric
        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;

        [Display(Name = "Age (2 - 120)")]
        [Range(2, 120, ErrorMessage = "Age must be between 2 and 120")]
        public int Age { get; set; }

        [Display(Name = "Weight - Stones")]
        [Range(1, 50, ErrorMessage = "Stones must be between 1 and 50")]                              // max 50 stone
        public int WeightStones { get; set; }

        [Display(Name = "Pounds")]
        [Range(0, 13, ErrorMessage = "Pounds must be between 0 and 13")]                              // 14 lbs in a stone
        public int WeightPounds { get; set; }

        [Display(Name = "Height - Feet")]
        [Range(1, 7, ErrorMessage = "Feet must be between 1 and 7")]                               // max 7 feet
        public int HeightFeet { get; set; }

        [Display(Name = "Inches")]
        [Range(0, 11, ErrorMessage = "Inches must be between 0 and 11")]                              // 12 inches in a foot
        public int HeightInches { get; set; }

        // calculate BMI, display to 2 decimal places
        [Display(Name = "Your BMI is")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BMIValue
        {
            get
            {
                // bmi = weight in Kgs / height in metres squared

                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

                return bmi;
            }
        }

        // calculate BMI category 
        [Display(Name = "Your BMI Category is")]
        public BMICategory BMICategory
        {
            get
            {
                double bmi = this.BMIValue;

                // calculate BMI category based on upper limits and age
                if (Age >= 2 && Age <= 18)
                {
                    // Apply child-specific BMI categories
                    if (bmi < 14) return BMICategory.Underweight;
                    if (bmi >= 14 && bmi < 20) return BMICategory.Normal;
                    if (bmi >= 20 && bmi < 25) return BMICategory.Overweight;
                    return BMICategory.Obese;
                }
                else if (Age > 18 && Age <= 65)
                {
                    // Adult BMI categories
                    if (bmi <= UnderWeightUpperLimit)
                    {
                        return BMICategory.Underweight;
                    }
                    else if (bmi <= NormalWeightUpperLimit)
                    {
                        return BMICategory.Normal;
                    }
                    else if (bmi <= OverWeightUpperLimit)
                    {
                        return BMICategory.Overweight;
                    }
                    else
                    {
                        return BMICategory.Obese;
                    }
                }
                else if (Age > 65)
                {
                    // Older adults may have different thresholds, placeholder logic here
                    if (bmi < 22) return BMICategory.Underweight;
                    if (bmi >= 22 && bmi < 28) return BMICategory.Normal;
                    if (bmi >= 28 && bmi < 32) return BMICategory.Overweight;
                    return BMICategory.Obese;
                }
                return BMICategory.NeedsAssessment; // Placeholder for values outside the typical range
            }
        }
    }
}
