using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery() : IRequest<IEnumerable<TaskItem>>;

}
