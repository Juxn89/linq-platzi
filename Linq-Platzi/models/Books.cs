namespace models
{
    public class Book {

        public string title { get; set; } = string.Empty;
        public int pageCount { get; set; }
        public DateTime publishedDate { get; set; }
        public string thumbnailUrl { get; set; } = string.Empty;
        public string shortDescription { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string[] authors { get; set; } = {};
        public string[] categories {get; set;} = {};
    }    
}
