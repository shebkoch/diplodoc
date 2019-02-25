using System;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
	public static class Rand
	{
		public static Random GetRandom()
		{
			return new Random((uint) DateTime.Now.Ticks);
		} 
	}
}