namespace MoviesAPI.Models.Request
{
    public class MovieEditRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
    }
}
