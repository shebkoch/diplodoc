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
			public ParametersComponent parametersComponent;
			public HybridDeathComponent deathComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Parameters entity in GetEntities<Parameters>())
			{
				int health = entity.parametersComponent.health;

				if (health <= 0)
				{
					PostUpdateCommands.DestroyEntity(entity.parametersComponent.gameObject.GetComponent<GameObjectEntity>().Entity);
					//ECS
					entity.deathComponent.DelayedDeath();
					//entity.parametersComponent.gameObject.SetActive(false);
				}
			}
		}
	}
}