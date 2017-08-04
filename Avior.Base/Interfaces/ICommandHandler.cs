namespace Avior.Base.Interfaces
{
	public interface ICommandHandler<TCommand>
	{
		void Handle(TCommand command);
	}
}