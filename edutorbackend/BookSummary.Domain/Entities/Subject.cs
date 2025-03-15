namespace BookSummary.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string SchoolLevel { get; set; } // E.g., "Primaria", "Secundaria", "Prepa", "Universidad"
        public string Grade { get; set; } // E.g., "1ro de Primaria", "2do de Primaria"
        public List<Day> Days { get; set; } // Days teaching this subject

        public Subject()
        {
            Days = new List<Day>();
        }
    }
}
