namespace MVCPlayer.Models
{
    public class Studio
    {
        public int ID { get; set; }

        public int StudioId { get; set; }

        public string? Name { get; set; }

        public int MovieId { get; set; }

        public Movie? Movie { get; set; }
    }
}