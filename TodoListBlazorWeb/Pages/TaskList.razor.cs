using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TodoList.Model;
using TodoListBlazorWeb.Services;

namespace TodoListBlazorWeb.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }
        private List<TaskDto> Task;
        protected override async Task OnInitializedAsync()
        {
            Task = await TaskApiClient.GetTaskList();
        }
    }
}
