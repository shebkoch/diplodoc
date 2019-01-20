using Scripts.Structures;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class AttackComponent : MonoBehaviour
	{	
		public float3 endPoint;
		public bool isAttackNeeded;
	}
}