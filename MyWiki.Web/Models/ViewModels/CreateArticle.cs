namespace MyWiki.Web.Models.ViewModels
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string UrlHandle { get; set; }
        public string FullDescription { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
    }
}
