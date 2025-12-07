using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(string Id, bool isCompleted) : IRequest<bool>;

}
