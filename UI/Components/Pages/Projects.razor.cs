using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Components.Pages
{
    // Context7 ve modern Razor için temiz code-behind
    public partial class ProjectsBase : ComponentBase
    {
        [Inject] protected IProjectService ProjectService { get; set; } = default!;

        protected List<Project>? projects;
        protected Project editProject = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadProjects();
        }

        protected async Task LoadProjects()
        {
            projects = (await ProjectService.GetAllProjectsAsync()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            if (editProject.Id == 0)
            {
                await ProjectService.CreateProjectAsync(editProject);
            }
            else
            {
                await ProjectService.UpdateProjectAsync(editProject.Id, editProject);
            }
            editProject = new();
            await LoadProjects();
        }

        protected void EditProject(Project project)
        {
            // Derin kopya ile formu doldur
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
            await ProjectService.DeleteProjectAsync(id);
            await LoadProjects();
        }
    }
}
