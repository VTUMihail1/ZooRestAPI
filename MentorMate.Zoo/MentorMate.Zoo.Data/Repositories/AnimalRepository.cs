using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Type = MentorMate.Zoo.Domain.Enums.Type;

namespace MentorMate.Zoo.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AnimalRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<IEnumerable<Animal>>> GetAllGroupedAndSortedAnimalsAsync()
        {
            var animals = await _applicationDbContext.Animals
                .AsNoTracking()
                .ToListAsync();

            var groupedAnimals = animals
                .GroupBy(a => a.Type)
                .OrderBy(g => g.Key)
                .ToDictionary(
                              g => g.Key,
                              g => g.OrderBy(item => item.Class));

            var groupedAndSortedAnimals = Enum
                .GetValues(typeof(Type))
                .Cast<Type>()
                .Select(
                        e => groupedAnimals
                        .TryGetValue(e, out var animals)
                                    ? animals
                                      .OrderBy(a => a.Class)
                                      .ThenBy(a => a.Weight)
                                    : Enumerable.Empty<Animal>());

            return groupedAndSortedAnimals;

        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            var animals = await _applicationDbContext.Animals
                .AsNoTracking()
                .ToListAsync();

            return animals;
        }

        public async Task<AnimalStatistics> GetAnimalTypeStatisticsAsync(Type type)
        {
            var animals = await _applicationDbContext.Animals
                .AsNoTracking()
                .ToListAsync();

            var animalTypeStatistics = animals
                .Where(a => a.Type == type)
                .GroupBy(a => a.Type)
                .Select(a => new AnimalStatistics
                {
                    MaxWeight = a.Max(p => p.Weight),
                    AverageWeight = a.Average(p => p.Weight)
                })
                .DefaultIfEmpty(new AnimalStatistics())
                .First();

            return animalTypeStatistics;
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            var animal = await _applicationDbContext.Animals
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return animal;
        }

        public async Task<Animal> GetByNameAsync(string name)
        {
            var animal = await _applicationDbContext.Animals
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            return animal;
        }

        public async Task AddAsync(Animal animal)
        {
            _applicationDbContext.Animals.Add(animal);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _applicationDbContext.Update(animal);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Animal animal)
        {
            _applicationDbContext.Animals.Remove(animal);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
