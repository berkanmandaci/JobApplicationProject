using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using JobApplicationProject.Services;
using JobApplicationProject.DTOs;
using Moq;
using AutoMapper;
namespace JobApplicationProject.Tests;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProjectService _service;

    public ProjectServiceTests()
    {
        _mockRepo = new Mock<IProjectRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new ProjectService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnProjectDto_WhenValid()
    {
        var dto = new ProjectDto { Name = "Test" };
        var entity = new Project { Name = "Test" };
        _mockMapper.Setup(m => m.Map<Project>(dto)).Returns(entity);
        _mockRepo.Setup(r => r.AddAsync(entity)).Returns(Task.CompletedTask);
        _mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);
        _mockMapper.Setup(m => m.Map<ProjectDto>(entity)).Returns(dto);

        var result = await _service.CreateAsync(dto);

        Assert.Equal("Test", result.Name);
        _mockRepo.Verify(r => r.AddAsync(entity), Times.Once);
        _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnProjectDtos()
    {
        var entities = new List<Project> { new Project { Name = "A" }, new Project { Name = "B" } };
        var dtos = new List<ProjectDto> { new ProjectDto { Name = "A" }, new ProjectDto { Name = "B" } };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mockMapper.Setup(m => m.Map<IEnumerable<ProjectDto>>(entities)).Returns(dtos);

        var result = await _service.GetAllAsync();

        Assert.Equal(2, ((List<ProjectDto>)result).Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProjectDto_WhenExists()
    {
        var entity = new Project { Id = 1, Name = "A" };
        var dto = new ProjectDto { Id = 1, Name = "A" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        _mockMapper.Setup(m => m.Map<ProjectDto>(entity)).Returns(dto);

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue_WhenValid()
    {
        var entity = new Project { Id = 1, Name = "A" };
        var dto = new ProjectDto { Id = 1, Name = "A" };
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
        var entity = new Project { Id = 1, Name = "A" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        _mockRepo.Setup(r => r.Delete(entity));
        _mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

        var result = await _service.DeleteAsync(1);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Project)null);

        var result = await _service.DeleteAsync(1);

        Assert.False(result);
    }
}