using UnityEngine;

namespace ECS.Component
{
	public class DurationComponent : MonoBehaviour
	{
		public bool isEnd;
		public float duration;
		public float last = float.MinValue;
		public bool isStartNeeded;
	}
}