namespace BookSummary.Application.Dtos
{
    public class ContentDto
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public int SubjectId { get; set; }
        public SubjectDto SubjectDto { get; set; }
    }
}
