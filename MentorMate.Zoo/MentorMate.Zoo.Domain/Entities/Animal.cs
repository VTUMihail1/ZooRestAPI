using MentorMate.Zoo.Domain.Enums;
using Type = MentorMate.Zoo.Domain.Enums.Type;

namespace MentorMate.Zoo.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public Type Type { get; set; }
        public Class Class { get; set; }
        public decimal Weight { get; set; }
    }
}
