using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class TestCollisionComponent : MonoBehaviour
	{
		public float radius;
		public int3 position;
		public CollisionType type;
		public List<Entity> collisions;
	}

	public enum TestCollisionType
	{
		Enemy,Damage,Player,PickUp,Obstacle
	}
}