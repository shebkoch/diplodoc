using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Enemy
{
	public class ExplodeEnemyComponent : MonoBehaviour
	{
		public float distance;
		public int damage;
		public GameObject particle;
	}
}