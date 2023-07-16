using MentorMate.Zoo.Business.Models.Food;

namespace MentorMate.Zoo.Business.Factories
{
    public interface IFoodFactory
    {
        IFood GetCarnivoreFood(decimal maxWeigth, decimal animalWeight);
        IFood GetHerbivoreFood(decimal averageWeight, decimal animalWeight);
        IFood GetOmnivoreFood(decimal averageWeight, decimal maxWeigth, decimal animalWeight);
    }
}
