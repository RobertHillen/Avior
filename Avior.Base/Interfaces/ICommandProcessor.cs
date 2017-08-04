namespace Avior.Base.Interfaces
{
	public interface ICommandProcessor
	{
		bool CanExecute(object command);
		void Execute(object command);
	}
}