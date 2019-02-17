using Scripts.Structures;
using UnityEngine;

namespace ECS.Component
{
	public class MapComponent : MonoBehaviour
	{
		public entity4[,] map = new entity4[1000, 1000];
	}
}