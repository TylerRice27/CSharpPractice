namespace CSharpPractice.Models
{
    public class TeamUp
    {
        public int Id { get; set; }

        public int HeroId { get; set; }

        public int VillainId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}