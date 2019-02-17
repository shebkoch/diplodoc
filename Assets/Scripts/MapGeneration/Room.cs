using System;

namespace DefaultNamespace.MapGeneration
{
	[Serializable]
	public struct Room
	{
		public int x, y, w, h;

		public bool Intersect(Room r)
		{
			return !(r.x >= x + w || x >= r.x + r.w || r.y >= y + h || y >= r.y + r.h);
		}
	}
}