using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class СreatureDeathSystem : ComponentSystem
	{
		protected struct Creature
		{
			public ParametersComponent parametersComponent;
			public DeathComponent deathComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{
				int health = entity.parametersComponent.health;

				if (health > 0) continue;

				entity.deathComponent.isDeathNeed = true;
			} 
		}


	}
}