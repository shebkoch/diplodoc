using ECS.Component;
using ECS.Component.Enemy;
using ECS.System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
	public class ExplodeEnemySystem : ComponentSystem
	{
		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public ExplodeEnemyComponent explodeEnemyComponent;
			public PlayerFollowComponent playerFollowComponent;
			public DeathComponent deathComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public ParametersComponent parametersComponent;
		}
		
		protected override void OnUpdate()
		{
			int damage = 0;
			foreach (Enemy entity in GetEntities<Enemy>())
			{
				float explodeDistance = entity.explodeEnemyComponent.distance;
				float distanceToPlayer = entity.playerFollowComponent.distanceToPlayer;
				int explodeDamage = entity.explodeEnemyComponent.damage;

				if (math.abs(distanceToPlayer) < math.abs(explodeDistance))
				{
					damage += explodeDamage;
					entity.deathComponent.isDeathNeed = true;
					GameObject.Instantiate(entity.explodeEnemyComponent.particle, entity.explodeEnemyComponent.transform.position, quaternion.identity);
				}
			}

			foreach (var entity in GetEntities<Player>())
			{
				entity.parametersComponent.health -= damage;
			}
		}
	}
}