using MentorMate.Zoo.Business.Constants;

namespace MentorMate.Zoo.Business.Models.Food
{
    public class OmnivoreFood : IFood
    {
        public OmnivoreFood(decimal averageWeight, decimal maxWeight, decimal animalWeight)
        {
            Amount = ((maxWeight + animalWeight * AnimalFoodDetails.WeightMultiplier)
                     * AnimalFoodDetails.FoodMultiplier)
                     + ((averageWeight + animalWeight * AnimalFoodDetails.WeightMultiplier)
                     * AnimalFoodDetails.FoodMultiplier);
        }

        public decimal Amount { get; }
    }
}
