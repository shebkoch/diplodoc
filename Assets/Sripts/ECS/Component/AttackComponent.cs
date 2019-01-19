using Sripts.Structures;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class AttackComponent : MonoBehaviour
	{
		public quaternion direction;
		public float3 startPoint;
		public Weapon weapon;
	}
}