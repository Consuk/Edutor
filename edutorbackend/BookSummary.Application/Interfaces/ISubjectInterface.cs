namespace BookSummary.Application.Interfaces
{
    public interface ISubjectInterface
    {
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<SubjectDto> CreateSubjectAsync(SubjectDto SubjectDto);
        Task<SubjectDto> GetSubjectListAsync();
        Task<SubjectDto> DeleteSubjectByIdAsync(int id);
        Task<SubjectDto> UpdateSubjectByIdAsync(int id);
    }
}
