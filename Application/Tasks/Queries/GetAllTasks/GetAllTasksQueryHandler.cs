using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler :
        IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
    {
        private readonly ITaskRepository _repo;

        public GetAllTasksQueryHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
