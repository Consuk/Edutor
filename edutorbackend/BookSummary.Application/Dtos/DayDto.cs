namespace BookSummary.Application.Dtos
{
    public class DayDto
    {
        public int DayId { get; set; }
        public DateTime DateD { get; set; }
        public int ContentId { get; set; }
        public ContentDto ContentDto { get; set; }
        public string Summary { get; set; }
        public string TextSnippet { get; set; }
        public int StartWordIndex { get; set; }
        public int EndWordIndex { get; set; }
    }
}
