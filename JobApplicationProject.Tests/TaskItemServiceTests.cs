using Xunit;
using Moq;
using JobApplicationProject.Services;
using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using JobApplicationProject.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;

public class TaskItemServiceTests
{
    private readonly Mock<ITaskItemRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly TaskItemService _service;

    public TaskItemServiceTests()
    {
        _mockRepo = new Mock<ITaskItemRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new TaskItemService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnTaskItemDto_WhenValid()
    {
        var dto = new TaskItemDto { Name = "Test" };
        var entity = new TaskItem { Name = "Test" };
        _mockMapper.Setup(m => m.Map<TaskItem>(dto)).Returns(entity);
        _mockRepo.Setup(r => r.AddAsync(entity)).Returns(Task.CompletedTask);
        _mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);
        _mockMapper.Setup(m => m.Map<TaskItemDto>(entity)).Returns(dto);

        var result = await _service.CreateAsync(dto);

        Assert.Equal("Test", result.Name);
        _mockRepo.Verify(r => r.AddAsync(entity), Times.Once);
        _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnTaskItemDtos()
    {
        var entities = new List<TaskItem> { new TaskItem { Name = "A" }, new TaskItem { Name = "B" } };
        var dtos = new List<TaskItemDto> { new TaskItemDto { Name = "A" }, new TaskItemDto { Name = "B" } };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mockMapper.Setup(m => m.Map<IEnumerable<TaskItemDto>>(entities)).Returns(dtos);

        var result = await _service.GetAllAsync();

        Assert.Equal(2, ((List<TaskItemDto>)result).Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnTaskItemDto_WhenExists()
    {
        var entity = new TaskItem { Id = 1, Name = "A" };
        var dto = new TaskItemDto { Id = 1, Name = "A" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        _mockMapper.Setup(m => m.Map<TaskItemDto>(entity)).Returns(dto);

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue_WhenValid()
    {
        var entity = new TaskItem { Id = 1, Name = "A" };
        var dto = new TaskItemDto { Id = 1, Name = "A" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        _mockMapper.Setup(m => m.Map(dto, entity));
        _mockRepo.Setup(r => r.Update(entity));
        _mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

        var result = await _service.UpdateAsync(1, dto);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenExists()
    {
        var entity = new TaskItem { Id = 1, Name = "A" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        _mockRepo.Setup(r => r.Delete(entity));
        _mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

        var result = await _service.DeleteAsync(1);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((TaskItem)null);

        var result = await _service.DeleteAsync(1);

        Assert.False(result);
    }
}