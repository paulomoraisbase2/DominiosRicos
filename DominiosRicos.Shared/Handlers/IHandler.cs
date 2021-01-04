using DominiosRicos.Shared.Commands;

namespace DominiosRicos.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}