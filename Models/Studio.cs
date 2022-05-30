namespace MVCPlayer.Models
{
    public class Studio
    {
        public int Id { get; set;}

        public virtual ICollection<Movie>? Name { get; set; }

    }
}