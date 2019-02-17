using System;
using Unity.Mathematics;

namespace DefaultNamespace.MapGeneration
{
	[Serializable]
	public struct Triangle
	{
		public int2 p1, p2, p3;

		public void Sort()
		{
			if (p1.y > p2.y)
				swap(ref p1, ref p2);
			if (p1.y > p3.y)
				swap(ref p1, ref p3);
			if (p2.y > p3.y)
				swap(ref p2, ref p3);
		}

		private void swap(ref int2 a, ref int2 b)
		{
			var buff = a;
			a = b;
			b = buff;
		}
	}
}