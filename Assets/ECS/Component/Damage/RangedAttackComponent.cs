using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class RangedAttackComponent : MonoBehaviour
	{
		public float3 endPoint;
		public bool isAttackNeed;
	}
}