using UnityEngine;

namespace ECS.Component.Attack
{
	public class MeleeAttackComponent : MonoBehaviour
	{
		public bool isAttackNeed;
		public Collider2D weaponCollider;
	}
}