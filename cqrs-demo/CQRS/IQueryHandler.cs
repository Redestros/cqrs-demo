namespace cqrs_demo.CQRS
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}
