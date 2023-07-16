using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Domain.Models;
using Type = MentorMate.Zoo.Domain.Enums.Type;

namespace MentorMate.Zoo.Data.Repositories
{
    public interface IAnimalRepository
    {
        Task<AnimalStatistics> GetTypeStatisticsAsync(Type type);
        Task<IEnumerable<IEnumerable<Animal>>> GetAllGroupedAndSortedAsync();
        Task AddAsync(Animal animal);
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByIdAsync(int id);
        Task<Animal> GetByNameAsync(string name);
        Task DeleteAsync(Animal animal);
        Task UpdateAsync(Animal animal);
    }
}