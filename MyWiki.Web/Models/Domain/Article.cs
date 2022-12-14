namespace MyWiki.Web.Models.Domain
{
    //all property values must be entered
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UrlHandle { get; set; }
        public string FullDescription { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public ICollection<IssueType> IssueTypes { get; set; }
    }
}
