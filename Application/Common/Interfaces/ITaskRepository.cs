using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(string id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task InsertAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(string id);
    }
}
