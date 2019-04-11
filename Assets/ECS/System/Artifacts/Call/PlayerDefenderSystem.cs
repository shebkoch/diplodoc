using ECS.Component;
using ECS.Component.Artifacts.Call;
using ECS.Component.Attack;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts.Call
{
	public class PlayerDefenderSystem : ComponentSystem
	{
		protected struct Settings
		{
			public PlayerDefenderSettings playerDefenderSettings;
		}
		protected struct Defender
		{
			public PlayerDefenderComponent playerDefenderComponent;
			public RangedAttackComponent rangedAttackComponent;
		}
		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public PlayerFollowComponent playerFollowComponent;
			public Transform transform;
		}
		protected override void OnUpdate()
		{
			float distanceToPlayer = 0;
			foreach (var entity in GetEntities<Settings>()) distanceToPlayer = entity.playerDefenderSettings.distanceToPlayer;

			float3 position = 0;
			foreach (var entity in GetEntities<Enemy>())
			{
				float3 enemyPos = entity.transform.position;
				float enemyDistance = entity.playerFollowComponent.distanceToPlayer;
				if (math.abs(enemyDistance) < math.abs(distanceToPlayer))
				{
					position = enemyPos;
				}
			}
			
			foreach (Defender entity in GetEntities<Defender>())
			{
				entity.rangedAttackComponent.endPoint = position;
				entity.rangedAttackComponent.isAttackNeed = true;
			}
		}
	}
}