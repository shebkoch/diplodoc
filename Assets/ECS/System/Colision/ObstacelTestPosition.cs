using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	public class ObstacelTestPosition : ComponentSystem
	{
		protected struct Collision
		{
			public TestCollisionComponent testCollisionComponent;
			public MovingComponent movingComponent;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			foreach (Collision entity in GetEntities<Collision>())
			{
				
			}
		}


	}
}