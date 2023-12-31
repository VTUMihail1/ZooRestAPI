﻿using MentorMate.Zoo.Business.Models.Food;
using MentorMate.Zoo.Domain.Models;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;

namespace MentorMate.Zoo.Business.Strategy
{
    public interface IFoodStrategy
    {
        IFood CalculateAnimalFood(AnimalStatistics animalStatistics, AnimalViewDTO animalViewDTO);
    }
}