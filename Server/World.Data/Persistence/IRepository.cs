using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.WorldModel;
using SquareArch.DomainModel;

namespace SquareArch.DomainModel.Persistence
{
	public interface IRepository<T> where T : Entity
	{
		T Get(Guid ID);
		IEnumerable<T> Get();
		IEnumerable<T> Get(Func<T, bool> filter);

		void Add(T item);
		void Delete(T item);
		void Update(T item);
	}
}
