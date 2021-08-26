using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Dto.ToDoItem;
using Services.Abstractions.Service;

namespace Presentation.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        readonly IServiceManager serviceManager;
        public ToDosController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItemDto>> GetAllTodos()
        {
            return await serviceManager.ToDosService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ToDoItemDto> Create(CreateToDoItemDto model)
        {
            return await serviceManager.ToDosService.CreateAsync(model);
        }

        [HttpGet("{id:guid}")]
        public async Task<ToDoItemDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return await serviceManager.ToDosService.GetByIdAsync(id, cancellationToken);
        }
    }
}
