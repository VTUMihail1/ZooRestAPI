using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentorMate.Zoo.Data.EntityConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(DatabaseConfigurationConstants.AnimalNameMaxLength)
                .ValueGeneratedNever();

            builder
                .Property(a => a.Species)
                .IsRequired()
                .HasMaxLength(DatabaseConfigurationConstants.AnimalSpeciesMaxLength);

            builder
                .Property(a => a.Type)
                .IsRequired();

            builder
                .Property(a => a.Class)
                .IsRequired();

            builder
                .Property(a => a.Weight)
                .IsRequired();
        }
    }
}
