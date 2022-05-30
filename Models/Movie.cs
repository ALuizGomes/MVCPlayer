using System.ComponentModel.DataAnnotations;

namespace MVCPlayer.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [DataType(DataType.Date)]

        public DateTime ReleaseDate { get; set; }

        public string? Genre { get; set; }

        public decimal Price { get; set; }
    }

    public class Studio
    {
        public int Id { get; set;}

        public string? Nome { get; set; }
    }
    
}