using MediatR;
using Tmdb.Core.Results;

namespace Tmdb.Core.Utils
{
    public abstract class CommandBase : IRequest<ResultModel> { }
}
