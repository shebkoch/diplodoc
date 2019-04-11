using System.Collections.Generic;
using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Enemy;
using ECS.Component.Pool;
using ECS.System.Pool;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.System.Enemy
{
	[UpdateBefore(typeof(PullSystem))]
	public class EnemyGeneratorSystem : ComponentSystem
	{
		protected struct EnemyGenerator
		{
			public EnemyGeneratorComponent enemyGeneratorComponent;
			public CooldownComponent cooldownComponent;
			public PullComponent pullComponent;
			public RadiusComponent radiusComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}
		
		protected override void OnUpdate()
		{
			float3 playerPos = new float3();
			foreach (var entity in GetEntities<Player>())
			{
				playerPos = entity.transform.position;
			}
			foreach (var entity in GetEntities<EnemyGenerator>())
			{
				bool canUse = entity.cooldownComponent.canUse;
				if(!canUse) continue;

				List<SpawnPair> enemies = entity.enemyGeneratorComponent.enemies;
				int wave = entity.enemyGeneratorComponent.wave;
				int breakAfter = entity.enemyGeneratorComponent.breakAfter;
				int spread = entity.enemyGeneratorComponent.spread;
				int wavePlus = entity.enemyGeneratorComponent.wavePlus;
				
				if (wave % breakAfter != 0)
				{
					foreach (var spawnPair in enemies)
					{
						List<GameObject> gameObjects = new List<GameObject>();
						float relativeSpread = (float) spread / spawnPair.count;
						int count = spawnPair.count + wave * wavePlus;
						count += (int)Random.Range(-count * relativeSpread, count * relativeSpread);
						for (int i = 0; i < count; i++)
						{
							GameObject enemy = GameObject.Instantiate(spawnPair.gameObject);
							gameObjects.Add(enemy);
							enemy.SetActive(false);
						}

						entity.pullComponent.objects.AddRange(gameObjects);
						entity.radiusComponent.startPos = playerPos;
					}
				}

				entity.enemyGeneratorComponent.wave = wave + 1;
				entity.cooldownComponent.isReloadNeeded = true;
			}			
			
		}
	}
}