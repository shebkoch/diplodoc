using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	public class CollisionSystem : ComponentSystem
	{
		protected struct Entity
		{
			public CollisionComponent collisionComponent;
			public ParametersComponent parametersComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Entity entity in GetEntities<Entity>())
			{
				int receivedDamage = entity.collisionComponent.receivedDamage;
				if (receivedDamage <= 0) continue;
				
				int health = entity.parametersComponent.health;

				health -= receivedDamage;
				
			
				entity.collisionComponent.receivedDamage = 0;
				entity.parametersComponent.health = health;
			}
		}
	}
}