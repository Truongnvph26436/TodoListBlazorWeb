using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Model;
using Task = TodoListBlazor.Api.Enities.Task;

namespace TodoListBlazor.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTaskList();

        Task<Task> Create(Task task);

        Task<Task> Update(Task task);

        Task<Task> Delete(Task task);

        Task<Task> GetById(Guid id);
    }
}
