using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class TestCollisionComponent : MonoBehaviour
	{
		public List<Entity> collisions;
		public int3 position;
		public float radius;
		public CollisionType type;
	}

	public enum TestCollisionType
	{
		Enemy,
		Damage,
		Player,
		PickUp,
		Obstacle
	}
}