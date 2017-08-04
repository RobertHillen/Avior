namespace Avior.Base.Interfaces
{
	public interface IQueryHandler<TQuery, TResult>
	{
		TResult Handle(TQuery query);
	}
}