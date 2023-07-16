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
                .HasColumnType(DatabaseConfiguration.StringDatabaseType)
                .HasMaxLength(DatabaseConfiguration.AnimalNameMaxLength);

            builder
                .Property(a => a.Species)
                .IsRequired()
                .HasColumnType(DatabaseConfiguration.StringDatabaseType)
                .HasMaxLength(DatabaseConfiguration.AnimalSpeciesMaxLength);

            builder
                .Property(a => a.Type)
                .IsRequired()
                .HasColumnType(DatabaseConfiguration.Int16DatabaseType);

            builder
                .Property(a => a.Class)
                .IsRequired()
                .HasColumnType(DatabaseConfiguration.Int16DatabaseType);

            builder
                .Property(a => a.Weight)
                .IsRequired()
                .HasColumnType(DatabaseConfiguration.DecimalDatabaseType)
                .HasPrecision(DatabaseConfiguration.DecimalPrecision, DatabaseConfiguration.DecimalScale);
        }
    }
}
