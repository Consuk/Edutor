using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookSummary.Application.Dtos;
using BookSummary.Application.Interfaces;
using BookSummary.Domain.Entities;

namespace BookSummary.Application.Services
{
    public class DayService : IDayInterface
    {
        private readonly IRepository<Day> _dayRepository;
        private readonly IMapper _mapper;

        public DayService(IRepository<Day> dayRepository, IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }

        public async Task<DayDto> GetDayByIdAsync(int dayId)
        {
            try
            {
                var day = await _dayRepository.GetByIdAsync(dayId);
                return _mapper.Map<DayDto>(day);
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException($"Failed to retrieve day by ID: {dayId}", ex);
            }
        }

        public async Task<IEnumerable<DayDto>> GetAllDaysAsync()
        {
            var days = await _dayRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DayDto>>(days);
        }

        public async Task<DayDto> CreateDayAsync(DayDto dayDto)
        {
            var day = _mapper.Map<Day>(dayDto);
            var result = await _dayRepository.AddAsync(day);
            return _mapper.Map<DayDto>(result);
        }

        public async Task UpdateDayAsync(DayDto dayDto)
        {
            var day = _mapper.Map<Day>(dayDto);
            await _dayRepository.UpdateAsync(day);
        }

        public async Task DeleteDayAsync(int dayId)
        {
            try
            {
                var day = await _dayRepository.GetByIdAsync(dayId);
                if (day != null)
                {
                    await _dayRepository.DeleteAsync(day);
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException($"Failed to delete day with ID: {dayId}", ex);
            }
        }
    }
}
