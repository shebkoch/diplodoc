using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class CooldownComponent : MonoBehaviour
	{
		public bool canUse;
		public float cooldown;
		public float last = float.MinValue;
	}
}