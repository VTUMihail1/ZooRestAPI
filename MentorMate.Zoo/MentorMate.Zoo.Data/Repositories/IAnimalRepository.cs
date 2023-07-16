using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Domain.Models;
using Type = MentorMate.Zoo.Domain.Enums.Type;

namespace MentorMate.Zoo.Data.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal> GetByIdAsync(int id);
        Task<Animal> GetByNameAsync(string name);
        Task<AnimalStatistics> GetAnimalTypeStatisticsAsync(Type type);
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<IEnumerable<IEnumerable<Animal>>> GetAllGroupedAndSortedAnimalsAsync();
        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(Animal animal);
    }
}