using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookSummary.Application.Dtos;
using BookSummary.Application.Interfaces;
using BookSummary.Domain.Entities;

namespace BookSummary.Application.Services
{
    public class SubjectService : ISubjectInterface
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(IRepository<Subject> subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(int subjectId)
        {
            try
            {
                var subject = await _subjectRepository.GetByIdAsync(subjectId);
                return _mapper.Map<SubjectDto>(subject);
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException(
                    $"Failed to retrieve subject by ID: {subjectId}",
                    ex
                );
            }
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> CreateSubjectAsync(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            var result = await _subjectRepository.AddAsync(subject);
            return _mapper.Map<SubjectDto>(result);
        }

        public async Task UpdateSubjectAsync(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(int subjectId)
        {
            try
            {
                var subject = await _subjectRepository.GetByIdAsync(subjectId);
                if (subject != null)
                {
                    await _subjectRepository.DeleteAsync(subject);
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException(
                    $"Failed to delete subject with ID: {subjectId}",
                    ex
                );
            }
        }
    }
}
