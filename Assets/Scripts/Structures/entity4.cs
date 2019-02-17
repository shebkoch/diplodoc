using System.Collections.Generic;
using Unity.Entities;

namespace Scripts.Structures
{
	public struct entity4
	{
		public Entity x;
		public Entity y;
		public Entity z;
		public Entity w;

		//ECS split in to logic and data
		public void SetAny(Entity entity)
		{
			if (x == entity || y == entity || z == entity || w == entity) return;

			if (x.Index == 0) x = entity;
			else if (y.Index == 0) y = entity;
			else if (z.Index == 0) z = entity;
			else w = entity;
		}

		public IEnumerable<Entity> Get()
		{
			yield return x;
			yield return y;
			yield return z;
			yield return w;
		}
	}
}