using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Type = MentorMate.Zoo.Domain.Enums.Type;

namespace MentorMate.Zoo.Data.Seed
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DatabaseInitializer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task InitializeAsync()
        {
            await MigrateAsync();
            await SeedAnimalsAsync();
        }

        private async Task MigrateAsync()
        {
            var pendingMigrations = await _applicationDbContext.Database.GetPendingMigrationsAsync();

            var thereArePendingMigrations = pendingMigrations.Count() > default(int);

            if (thereArePendingMigrations)
            {
                await _applicationDbContext.Database.MigrateAsync();
            }
        }

        private async Task SeedAnimalsAsync()
        {
            if (await _applicationDbContext.Animals.AnyAsync())
            {
                return;
            }

            var animals = new List<Animal>
            {
                new Animal
                {
                    Name = "Lion",
                    Species = "Panthera leo",
                    Type = Type.Carnivore,
                    Class = Class.Mammal,
                    Weight = 190.5m
                },
                new Animal
                {
                    Name = "Tiger",
                    Species = "Panthera tigris",
                    Type = Type.Carnivore,
                    Class = Class.Mammal,
                    Weight = 220.2m
                },
                new Animal
                {
                    Name = "Elephant",
                    Species = "Loxodonta africana",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 5000.0m
                },
                new Animal
                {
                    Name = "Hawk",
                    Species = "Buteo jamaicensis",
                    Type = Type.Carnivore,
                    Class = Class.Bird,
                    Weight = 1.5m
                },
                new Animal
                {
                    Name = "Salmon",
                    Species = "Salmo salar",
                    Type = Type.Omnivore,
                    Class = Class.Fish,
                    Weight = 5.0m
                },
                new Animal
                {
                    Name = "Dog",
                    Species = "Canis lupus familiaris",
                    Type = Type.Omnivore,
                    Class = Class.Mammal,
                    Weight = 25.0m
                },
                new Animal
                {
                    Name = "Cat",
                    Species = "Felis catus",
                    Type = Type.Carnivore,
                    Class = Class.Mammal,
                    Weight = 4.5m
                },
                new Animal
                {
                    Name = "Eagle",
                    Species = "Aquila chrysaetos",
                    Type = Type.Carnivore,
                    Class = Class.Bird,
                    Weight = 6.0m
                },
                new Animal
                {
                    Name = "Crocodile",
                    Species = "Crocodylus niloticus",
                    Type = Type.Carnivore,
                    Class = Class.Reptile,
                    Weight = 1000.0m
                },
                new Animal
                {
                    Name = "Giraffe",
                    Species = "Giraffa camelopardalis",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 1600.0m
                },
                new Animal
                {
                    Name = "Toucan",
                    Species = "Ramphastos toco",
                    Type = Type.Omnivore,
                    Class = Class.Bird,
                    Weight = 0.5m
                },
                new Animal
                {
                    Name = "Butterfly",
                    Species = "Papilio machaon",
                    Type = Type.Herbivore,
                    Class = Class.Invertebrate,
                    Weight = 0.01m
                },
                new Animal
                 {
                     Name = "Dolphin",
                     Species = "Delphinus delphis",
                     Type = Type.Carnivore,
                     Class = Class.Mammal,
                     Weight = 150.0m
                },
                new Animal
                {
                    Name = "Penguin",
                    Species = "Spheniscus demersus",
                    Type = Type.Carnivore,
                    Class = Class.Bird,
                    Weight = 20.0m
                },
                new Animal
                {
                    Name = "Snake",
                    Species = "Python regius",
                    Type = Type.Carnivore,
                    Class = Class.Reptile,
                    Weight = 2.5m
                },
                new Animal
                {
                    Name = "Kangaroo",
                    Species = "Macropus giganteus",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 70.0m
                },
                new Animal
                {
                    Name = "Octopus",
                    Species = "Octopus vulgaris",
                    Type = Type.Carnivore,
                    Class = Class.Invertebrate,
                    Weight = 3.0m
                },
                new Animal
                {
                    Name = "Frog",
                    Species = "Litoria caerulea",
                    Type = Type.Carnivore,
                    Class = Class.Amphibian,
                    Weight = 0.1m
                },
                new Animal
                {
                    Name = "Gorilla",
                    Species = "Gorilla gorilla",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 180.0m
                },
                new Animal
                {
                    Name = "Lionfish",
                    Species = "Pterois volitans",
                    Type = Type.Carnivore,
                    Class = Class.Fish,
                    Weight = 0.5m
                },
                new Animal
                {
                    Name = "Ostrich",
                    Species = "Struthio camelus",
                    Type = Type.Herbivore,
                    Class = Class.Bird,
                    Weight = 100.0m
                },
                new Animal
                {
                    Name = "Komodo Dragon",
                    Species = "Varanus komodoensis",
                    Type = Type.Carnivore,
                    Class = Class.Reptile,
                    Weight = 70.0m
                },
                new Animal
                {
                    Name = "Gazelle",
                    Species = "Gazella dorcas",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 40.0m
                },
                new Animal
                {
                    Name = "Scorpion",
                    Species = "Heterometrus swammerdami",
                    Type = Type.Carnivore,
                    Class = Class.Invertebrate,
                    Weight = 0.1m
                },
                new Animal
                {
                    Name = "Tree Frog",
                    Species = "Hyla versicolor",
                    Type = Type.Carnivore,
                    Class = Class.Amphibian,
                    Weight = 0.02m
                },
                new Animal
                {
                    Name = "Panda",
                    Species = "Ailuropoda melanoleuca",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 100.0m
                },
                new Animal
                {
                    Name = "Shark",
                    Species = "Carcharodon carcharias",
                    Type = Type.Carnivore,
                    Class = Class.Fish,
                    Weight = 2000.0m
                },
                new Animal
                {
                    Name = "Parrot",
                    Species = "Ara macao",
                    Type = Type.Herbivore,
                    Class = Class.Bird,
                    Weight = 1.0m
                },
                new Animal
                {
                    Name = "Turtle",
                    Species = "Chelonia mydas",
                    Type = Type.Herbivore,
                    Class = Class.Reptile,
                    Weight = 150.0m
                },
                new Animal
                {
                    Name = "Gorilla",
                    Species = "Gorilla beringei",
                    Type = Type.Herbivore,
                    Class = Class.Mammal,
                    Weight = 180.0m
                },
                new Animal
                {
                    Name = "Spider",
                    Species = "Latrodectus mactans",
                    Type = Type.Carnivore,
                    Class = Class.Invertebrate,
                    Weight = 0.01m
                },
                new Animal
                {
                    Name = "Frog",
                    Species = "Rana temporaria",
                    Type = Type.Carnivore,
                    Class = Class.Amphibian,
                    Weight = 0.05m
                },
                new Animal
                {
                    Name = "Polar Bear",
                    Species = "Ursus maritimus",
                    Type = Type.Carnivore,
                    Class = Class.Mammal,
                    Weight = 900.0m
                }
            };

            _applicationDbContext.Animals.AddRange(animals);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
