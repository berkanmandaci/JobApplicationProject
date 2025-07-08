using AutoMapper;
using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using JobApplicationProject.DTOs;

namespace JobApplicationProject.Services
{
    public class TaskItemService : GenericService<TaskItem,TaskItemDto>, ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly IMapper _mapper;
        public TaskItemService(ITaskItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetTaskItemsByProjectIdAsync(long projectId)
        {
            var taskItems = await _repository.GetByProjectIdAsync(projectId);
            return _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
        }
    }
} 