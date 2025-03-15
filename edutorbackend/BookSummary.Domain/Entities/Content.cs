namespace BookSummary.Domain.Entities
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
