using MentorMate.Zoo.Business.Models.Results;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;

namespace MentorMate.Zoo.Business.Services
{
    public interface IAnimalService
    {
        Task<IResult<AnimalResultDTO>> AddAsync(AnimalAddDTO animalAddDTO);
        Task<IResult<AnimalResultDTO>> DeleteAsync(int id);
        Task<IEnumerable<IEnumerable<AnimalResultDTO>>> GetAllAsync();
        Task<IResult<AnimalViewDTO>> GetByIdAsync(int id);
        Task<IResult<AnimalResultDTO>> UpdateAsync(int id, AnimalUpdateDTO animalUpdateDTO);
    }
}