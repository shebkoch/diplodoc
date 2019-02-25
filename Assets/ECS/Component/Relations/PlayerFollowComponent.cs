using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class PlayerFollowComponent : MonoBehaviour
	{
		public float offset;
		public bool offsetEnable;
		public float distanceToPlayer;
	}
}