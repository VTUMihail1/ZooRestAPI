using MentorMate.Zoo.Business.Models.Food;
using MentorMate.Zoo.Domain.Models;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;
using Type = MentorMate.Zoo.Domain.Enums.Type;
using MentorMate.Zoo.Business.Factories;

namespace MentorMate.Zoo.Business.Strategy
{
    public class FoodStrategy : IFoodStrategy
    {
        private readonly IFoodFactory _foodFactory;

        public FoodStrategy(IFoodFactory foodFactory)
        {
            _foodFactory = foodFactory;
        }

        public IFood CalculateAnimalFood(AnimalStatistics animalStatistics, AnimalViewDTO animalViewDTO)
        {
            var maxWeight = animalStatistics.MaxWeight;
            var averageWeight = animalStatistics.MaxWeight;
            var animalWeight = animalViewDTO.Weight;

            if (animalViewDTO.Type == Type.Herbivore)
            {
                return _foodFactory.GetHerbivoreFood(maxWeight, averageWeight);
            }
            else if (animalViewDTO.Type == Type.Carnivore)
            {
                return _foodFactory.GetCarnivoreFood(maxWeight, animalWeight);
            }
            else
            {
                return _foodFactory.GetOmnivoreFood(averageWeight, maxWeight, animalWeight);
            }
        }
    }
}
