using System.Linq;
using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class BulletSystem : ComponentSystem
	{
		protected struct Bullet
		{
			public PlayerBulletComponent bulletComponent;
			public CollisionComponent collisionComponent;
			public ParametersComponent parametersComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Bullet entity in GetEntities<Bullet>())
			{
				var collisions = entity.collisionComponent.collisions;

				int size = collisions.Count(pair => pair.Key.type != CollisionType.Player &&
				                                    pair.Key.type != CollisionType.PlayerAttack);

				if (size > 0)
				{
					//TODO: remove that foreach
					foreach (var collision in collisions)
					{
						collision.Key.collisions.Remove(entity.collisionComponent);
					}

					entity.parametersComponent.health = 0;
				}
			}
		}


	}
}