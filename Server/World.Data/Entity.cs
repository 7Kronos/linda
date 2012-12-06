using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.WorldModel
{
	/// <summary>
	/// Un élément qui peut être persisté
	/// </summary>
	public abstract class Entity
	{
		public Guid ID { get; internal set; }
	}
}
