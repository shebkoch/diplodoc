using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class BulletDamageSystem : ComponentSystem
	{
		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public CollisionComponent collisionComponent;
			public DamageComponent damageComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Enemy entity in GetEntities<Enemy>())
			{
				foreach (var collision in entity.collisionComponent.collisions)
				{
					if (collision.Value == CollisionState.Enter  &&
					    collision.Key.type == CollisionType.Damage &&
					    collision.Key.isEnable)
					{
						entity.damageComponent.isDamageDeal = true;
					}
				}
			}
		}
	}
}