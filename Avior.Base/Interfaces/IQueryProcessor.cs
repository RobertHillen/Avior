namespace Avior.Base.Interfaces
{
	public interface IQueryProcessor
	{
		bool CanExecute<TResult>(IQuery<TResult> query);
		TResult Execute<TResult>(IQuery<TResult> query);
	}
}