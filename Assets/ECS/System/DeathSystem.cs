using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Pool;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class DeathSystem : ComponentSystem
	{
		protected struct Parameters
		{
			public DeathComponent deathComponent;
			public HybridDeathComponent hybridDeathComponent;
		}
		protected struct Pull
		{
			public PoolComponent poolComponent;
		}

		protected override void OnUpdate()
		{
			List<GameObject> enemies = new List<GameObject>();
			foreach (Parameters entity in GetEntities<Parameters>())
			{
				bool isDeathNeed = entity.deathComponent.isDeathNeed;
				bool isDie = entity.deathComponent.isDie;

				if (isDie || !isDeathNeed) continue;

				entity.deathComponent.isDie = true;
				entity.deathComponent.isDeathNeed = false;
				
				PostUpdateCommands.DestroyEntity(entity.hybridDeathComponent.entity);
				//ECS
				entity.hybridDeathComponent.DelayedDeath();
//				enemies.Add(entity.hybridDeathComponent.gameObject);
			}

			foreach (var entity in GetEntities<Pull>())
			{
				entity.poolComponent.enemies.AddRange(enemies);
			}
		}
	}
}