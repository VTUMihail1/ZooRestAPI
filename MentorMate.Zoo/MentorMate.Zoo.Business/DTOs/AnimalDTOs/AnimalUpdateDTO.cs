using System.Text.Json.Serialization;

namespace MentorMate.Zoo.Business.DTOs.AnimalDTOs
{
    public class AnimalUpdateDTO
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        [JsonIgnore]
        public bool ExistsInDatabase
        {
            get
            {
                return true;
            }
        }
    }
}
