using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double flourTypeCalories;
        private double bakingTechinqueCalories;
        private readonly List<string> validFlourTypes = new List<string> { "white", "wholegrain" };
        private readonly List<string> validBakingTechiques = new List<string> { "crispy", "chewy", "homemade" };

        private string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (!validFlourTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
                switch (flourType.ToLower())
                {
                    case "white": flourTypeCalories = 1.5; break;
                    case "wholegrain": flourTypeCalories = 1.0; break;
                }
            }
        }

        private string BakingTechique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (!validBakingTechiques.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
                switch (BakingTechique.ToLower())
                {
                    case "crispy": bakingTechinqueCalories = 0.9; break;
                    case "chewy": bakingTechinqueCalories = 1.1; break;
                    case "homemade": bakingTechinqueCalories = 1.0; break;
                }
            }
        }

        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechique = bakingTechnique;
            Weight = weight;
        }

        public double GetDoughCalories()
        {
            return 2.0 * weight * flourTypeCalories * bakingTechinqueCalories;
        }
    }
}
