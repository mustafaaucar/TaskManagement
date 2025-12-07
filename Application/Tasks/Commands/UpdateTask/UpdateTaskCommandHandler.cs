using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskRepository _repo;

        public UpdateTaskCommandHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repo.GetByIdAsync(request.Id);
            if (task == null)
            {
                return false;
            }

            task.IsCompleted = request.isCompleted;
            await _repo.UpdateAsync(task);
            return true;
        }

    }
}
