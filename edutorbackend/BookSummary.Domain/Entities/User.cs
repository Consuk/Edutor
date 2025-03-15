namespace BookSummary.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<Subject> Subjects { get; set; } // Subjects taught by the teacher

        public User()
        {
            Subjects = new List<Subject>();
        }
    }
}
