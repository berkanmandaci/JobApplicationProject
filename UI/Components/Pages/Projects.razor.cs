using Microsoft.AspNetCore.Components;
using JobApplicationProject.Contracts;
using JobApplicationProject.Models;


namespace UI.Components.Pages
{

    public partial class ProjectsBase : ComponentBase
    {
        [Inject] protected IProjectService ProjectService { get; set; } = default!;
        [Inject] protected ITaskItemService TaskItemService { get; set; } = default!;

        protected List<Project>? projects;
        protected Project editProject = new();
        protected TaskItem newTask = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadProjects();
        }

        protected async Task LoadProjects()
        {
            projects = (await ProjectService.GetAllAsync()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            if (editProject.Id == 0)
            {
                await ProjectService.CreateAsync(editProject);
            }
            else
            {
                await ProjectService.UpdateAsync(editProject.Id, editProject);
            }
            editProject = new();
            await LoadProjects();
        }

        protected void EditProject(Project project)
        {
        
            editProject = new Project
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        protected void CancelEdit()
        {
            editProject = new();
        }

        protected async Task DeleteProject(long id)
        {
            await ProjectService.DeleteAsync(id);
            await LoadProjects();
        }

        protected async Task AddTask(long projectId)
        {
            newTask.ProjectId = projectId;
            newTask.IsComplete = false; 
            await TaskItemService.CreateAsync(newTask);
            newTask = new();
            await LoadProjects();
        }

        protected async Task DeleteTask(long taskId, long projectId)
        {
            await TaskItemService.DeleteAsync(taskId);
            await LoadProjects();
        }

        protected async Task ToggleTaskComplete(TaskItem task, bool value)
        {
            task.IsComplete = value;
            await TaskItemService.UpdateAsync(task.Id, task);
            await LoadProjects();
        }
    }
}
