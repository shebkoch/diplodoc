using ECS.Component;
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

		protected override void OnUpdate()
		{
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
				
			}
		}
	}
}