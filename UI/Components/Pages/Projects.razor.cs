using Microsoft.AspNetCore.Components;
using JobApplicationProject.Contracts;
using JobApplicationProject.DTOs;


namespace UI.Components.Pages
{

    public partial class ProjectsBase : ComponentBase
    {
        [Inject] protected IProjectService ProjectService { get; set; } = default!;
        [Inject] protected ITaskItemService TaskItemService { get; set; } = default!;

        protected List<ProjectDto>? projects;
        protected ProjectDto editProject = new() { Name = string.Empty };
        protected TaskItemDto editTaskItem = new() { Name = string.Empty };

        // Popup state'leri
        protected bool showDeleteProjectConfirm = false;
        protected bool showDeleteTaskConfirm = false;
        protected long projectIdToDelete;
        protected long taskIdToDelete;
        protected long taskProjectIdToDelete;

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
            editProject = new() { Name = string.Empty };
            await LoadProjects();
        }
        
        protected async Task HandleValidTaskSubmit(long projectId)
        {
            if (editTaskItem.Id == 0)
            {
                await AddTask(projectId);
            }
            else
            {
                await UpdateTaskItem(editTaskItem);
            }
            editTaskItem = new() { Name = string.Empty };
            await LoadProjects();
        }

        protected async Task UpdateTaskItem(TaskItemDto taskItem)
        {
            taskItem.Name = editTaskItem.Name;
            await TaskItemService.UpdateAsync(taskItem.Id, taskItem);
        }


        protected void EditTask(TaskItemDto task)
        {
            editTaskItem = task;
        }
        protected void EditProject(ProjectDto project)
        {

            editProject = new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        protected void CancelEdit()
        {
            editProject = new() { Name = string.Empty };
        }


        protected async Task AddTask(long projectId)
        {
            editTaskItem.ProjectId = projectId;
            editTaskItem.IsComplete = false;
            await TaskItemService.CreateAsync(editTaskItem);
        }


        protected async Task ToggleTaskComplete(TaskItemDto task, bool value)
        {
            task.IsComplete = value;
            await TaskItemService.UpdateAsync(task.Id, task);
            await LoadProjects();
        }

        // Silme popup'ını açan metotlar
        protected void ConfirmDeleteProject(long id)
        {
            projectIdToDelete = id;
            showDeleteProjectConfirm = true;
        }

        protected void ConfirmDeleteTask(long taskId, long projectId)
        {
            taskIdToDelete = taskId;
            taskProjectIdToDelete = projectId;
            showDeleteTaskConfirm = true;
        }

        // Onay popup'ında "Evet"e basınca silen metotlar
        protected async Task DeleteProjectConfirmed()
        {
            await ProjectService.DeleteAsync(projectIdToDelete);
            showDeleteProjectConfirm = false;
            if (projectIdToDelete== editProject.Id)
            {
                editProject = new() { Name = string.Empty };
            }
            await LoadProjects();
        }

        protected async Task DeleteTaskConfirmed()
        {
            await TaskItemService.DeleteAsync(taskIdToDelete);
            showDeleteTaskConfirm = false;
            if (taskIdToDelete== editTaskItem.Id)
            {
                editTaskItem = new() { Name = string.Empty };
            }
            await LoadProjects();
        }

        // Onay popup'ında "Hayır"a basınca popup'ı kapatan metotlar
        protected void CancelDeleteProject()
        {
            showDeleteProjectConfirm = false;
        }

        protected void CancelDeleteTask()
        {
            showDeleteTaskConfirm = false;
        }
    }
}
