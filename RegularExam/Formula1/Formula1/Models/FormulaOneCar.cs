using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string modelField;
        private int horsepowerField;
        private double engineDisplacementField;
        public string Model 
        {
            get
            {
                return this.modelField;
            }

            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel);
                }
                else
                {
                    modelField = value;
                }
            }
        }

        public int Horsepower
        {
            get
            {
                return horsepowerField;
            }

            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1HorsePower);
                }
                else
                {
                    horsepowerField = value;
                }
            }
        }

        public double EngineDisplacement 
        {
            get
            {
                return engineDisplacementField;
            }

            private set
            {
                if(value < 1.6d || value > 2.0d)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1EngineDisplacement);
                }
                else
                {
                    engineDisplacementField = value;
                }
            }
        }

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
