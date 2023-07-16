using MentorMate.Zoo.Business.Constants;

namespace MentorMate.Zoo.Business.Models.Food
{
    public class CarnivoreFood : IFood
    {
        public CarnivoreFood(decimal maxWeight, decimal animalWeight)
        {
            Amount = maxWeight + (animalWeight * AnimalFoodDetails.WeightMultiplier);
        }

        public decimal Amount { get; }
    }
}
