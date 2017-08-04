using System;

namespace Avior.Base.Interfaces
{
	public interface IUnitOfWork: IDisposable
	{
		bool HasChanges();
		void SaveChanges();
	}
}