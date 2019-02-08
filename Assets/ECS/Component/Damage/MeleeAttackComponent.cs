using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class MeleeAttackComponent : MonoBehaviour
	{
		public bool isAttackNeed;
		public Collider2D weaponCollider;
	}
}