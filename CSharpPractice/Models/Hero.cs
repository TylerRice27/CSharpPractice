namespace CSharpPractice.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }

        public string Img { get; set; }
        public int CityId { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Profile Creator { get; set; }

    }
}