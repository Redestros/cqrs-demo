using Autofac;
using System;
using System.Linq;

namespace cqrs_demo.CQRS
{
    public interface ICommandProcessor
    {
        TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IComponentContext _context;

        public CommandProcessor(IComponentContext context)
        {
            _context = context;
        }

        public TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            var commandHandlerType = typeof(ICommandHandler<TCommand, TResult>);
            var targetHandlerInterface = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(t => commandHandlerType.IsAssignableFrom(t) && t.IsInterface);
            if (targetHandlerInterface == null)
            {
                return default;
            }

            dynamic targetHandler = _context.Resolve(targetHandlerInterface);
            return targetHandler.Handle(command);
        }
    }
}
