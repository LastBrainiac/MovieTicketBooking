namespace MTBS.MovieCatalogAPI.Models.Dtos
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string MovieLength { get; set; }
        public string ReleaseYear { get; set; }
        public byte[] ThumbnailPic { get; set; }
        public List<List<string>> StartTimes { get; set; }
    }
}
