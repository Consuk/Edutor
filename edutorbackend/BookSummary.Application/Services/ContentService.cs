using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookSummary.Application.Dtos;
using BookSummary.Application.Interfaces;
using BookSummary.Domain.Entities;

namespace BookSummary.Application.Services
{
    public class ContentService : IContentInterface
    {
        private readonly IRepository<Content> _contentRepository;
        private readonly IMapper _mapper;

        public ContentService(IRepository<Content> contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public async Task<ContentDto> GetContentByIdAsync(int contentId)
        {
            try
            {
                var content = await _contentRepository.GetByIdAsync(contentId);
                return _mapper.Map<ContentDto>(content);
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException(
                    $"Failed to retrieve content by ID: {contentId}",
                    ex
                );
            }
        }

        public async Task<IEnumerable<ContentDto>> GetAllContentsAsync()
        {
            var contents = await _contentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContentDto>>(contents);
        }

        public async Task<ContentDto> CreateContentAsync(ContentDto contentDto)
        {
            var content = _mapper.Map<Content>(contentDto);
            var result = await _contentRepository.AddAsync(content);
            return _mapper.Map<ContentDto>(result);
        }

        public async Task UpdateContentAsync(ContentDto contentDto)
        {
            var content = _mapper.Map<Content>(contentDto);
            await _contentRepository.UpdateAsync(content);
        }

        public async Task DeleteContentAsync(int contentId)
        {
            try
            {
                var content = await _contentRepository.GetByIdAsync(contentId);
                if (content != null)
                {
                    await _contentRepository.DeleteAsync(content);
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException(
                    $"Failed to delete content with ID: {contentId}",
                    ex
                );
            }
        }
    }
}
