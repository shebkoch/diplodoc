using System;
using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Stats;
using ECS.System.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System.Artifacts
{
	
	[UpdateAfter(typeof(ChanceByHpLoseSystem))]
	public class AroundShotSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public AroundShotPassiveArtifact aroundShotPassiveArtifact;
			public ChanceByHpLoseComponent chanceByHpLoseComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}
		
		protected override void OnUpdate()
		{
			Random random = Rand.GetRandom();
			float3 playerPos = new float3();
			foreach (var entity in GetEntities<Player>()) 
				playerPos = entity.transform.position;
		
			foreach (var entity in GetEntities<Artifact>())
			{
				bool isActivate = entity.chanceByHpLoseComponent.isActivate;
				GameObject bullet = entity.aroundShotPassiveArtifact.bullet;
				if (isActivate)
				{
					//TODO: fix anysizing
					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							if(i == 0 && j == 0) continue;
							GameObject bulletInstance = GameObject.Instantiate(bullet, playerPos, quaternion.identity);
							MovingComponent movingComponent = bulletInstance.GetComponent<MovingComponent>();
							movingComponent.vertical = i;
							movingComponent.horizontal = j;
						}
					}
				}
			}
		}
	}
}