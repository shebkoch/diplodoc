using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class CooldownSystem : ComponentSystem
	{
		protected struct Cooldown
		{
			public CooldownComponent cooldownComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Cooldown entity in GetEntities<Cooldown>())
			{
				bool canUse = entity.cooldownComponent.canUse;
				float cooldown = entity.cooldownComponent.cooldown;
				float last = entity.cooldownComponent.last;
				float currentTime = Time.realtimeSinceStartup;

				if (canUse || last + cooldown > currentTime) continue;

				entity.cooldownComponent.canUse = true;
			}
		}


	}
}