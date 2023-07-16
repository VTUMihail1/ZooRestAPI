using MentorMate.Zoo.Business.Models.Food;

namespace MentorMate.Zoo.Business.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood GetOmnivoreFood(decimal averageWeight, decimal maxWeigth, decimal animalWeight)
        {
            return new OmnivoreFood(averageWeight, maxWeigth, animalWeight);
        }

        public IFood GetHerbivoreFood(decimal averageWeight, decimal animalWeight)
        {
            return new HerbivoreFood(averageWeight, animalWeight);
        }

        public IFood GetCarnivoreFood(decimal maxWeigth, decimal animalWeight)
        {
            return new CarnivoreFood(maxWeigth, animalWeight);
        }
    }
}
