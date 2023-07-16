using MentorMate.Zoo.Business.Constants;

namespace MentorMate.Zoo.Business.Models.Food
{
    public class HerbivoreFood : IFood
    {
        public HerbivoreFood(decimal averageWeight, decimal animalWeight)
        {
            Amount = averageWeight + (animalWeight * AnimalFoodDetails.WeightMultiplier);
        }

        public decimal Amount { get; }
    }
}
