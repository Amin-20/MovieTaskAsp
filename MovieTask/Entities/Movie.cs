namespace MovieTask.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Language { get; set; }
        public DateTime Year { get; set;}
        public string? Runtime { get; set;}
    }
}
