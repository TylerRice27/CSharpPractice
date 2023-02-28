namespace CSharpPractice.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Img { get; set; }
        public string CreatorId { get; set; }

        public Profile Creator { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}