namespace MentorMate.Zoo.Data.Seed
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}