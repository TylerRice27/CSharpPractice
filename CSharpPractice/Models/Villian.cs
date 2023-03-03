namespace CSharpPractice.Models
{
    public class Villian
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Img { get; set; }

        public string Bio { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Profile Creator { get; set; }

    }
}