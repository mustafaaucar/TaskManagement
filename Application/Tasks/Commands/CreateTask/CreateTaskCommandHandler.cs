using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, string>
    {
        private readonly ITaskRepository _repo;

        public CreateTaskCommandHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };

            await _repo.InsertAsync(task);
            return task.Id!;
        }
    }
}
