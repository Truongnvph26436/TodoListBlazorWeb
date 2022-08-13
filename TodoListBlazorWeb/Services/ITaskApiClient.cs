using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorWeb.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();

        Task<TaskDto> GetTaskDetail(string id);
    }
}
