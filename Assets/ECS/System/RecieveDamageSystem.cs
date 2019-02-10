using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class RecieveDamageSystem : ComponentSystem
	{
		protected struct Enemy
		{
			public CollisionComponent collisionComponent;
			public DamageComponent damageComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Enemy entity in GetEntities<Enemy>())
			{
				var recieveFrom = entity.collisionComponent.receivedDamageFrom;

				for (var i = 0; i < entity.collisionComponent.enterList.Count; i++)
				{
					var collision = entity.collisionComponent.enterList[i];
					if (collision.type == recieveFrom && collision.isEnable)
					{
						entity.damageComponent.isDamageDeal = true;
						entity.collisionComponent.enterList.Remove(collision);
					}
				}

				foreach (var collision in entity.collisionComponent.collisions)
				{
					if (collision.Value == CollisionState.Enter  &&
					    collision.Key.type == recieveFrom &&
					    collision.Key.isEnable)
					{
						
					}
				}
			}
		}
	}
}