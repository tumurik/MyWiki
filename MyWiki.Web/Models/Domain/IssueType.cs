namespace MyWiki.Web.Models.Domain
{
    public class IssueType
    {
        public Guid Id { get; set; } 
        public string Type { get; set; }
        public Guid ArticleId { get; set; }
    }
}
