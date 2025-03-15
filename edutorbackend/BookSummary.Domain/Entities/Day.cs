namespace BookSummary.Domain.Entities
{
    public class Day
    {
        public int DayId { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public string TextSnippet { get; set; }
        public int StartWordIndex { get; set; }
        public int EndWordIndex { get; set; }
        public int SubjectId { get; set; } // Link back to the subject
        public Subject Subject { get; set; }
    }
}
