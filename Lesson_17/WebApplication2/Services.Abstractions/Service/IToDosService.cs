using Services.Abstractions.Dto.ToDoItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Service
{
    public interface IToDosService
    {
        Task<IEnumerable<ToDoItemDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ToDoItemDto>> GetAllCompletedTodos(CancellationToken cancellationToken = default);
        Task<ToDoItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ToDoItemDto> CreateAsync(CreateToDoItemDto model, CancellationToken cancellationToken = default);
        Task UpdateAsync(UpdateToDoItemDto model, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
