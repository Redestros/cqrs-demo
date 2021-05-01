namespace cqrs_demo.CQRS
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        TResult Handle(TCommand command);
    }
}
