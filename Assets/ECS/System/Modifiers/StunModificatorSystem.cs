using ECS.Component;
using ECS.System;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
	[UpdateAfter(typeof(PlayerFollowSystem))] 
	public class StunModificatorSystem : ComponentSystem
	{
		protected struct Modificator
		{
			public StunModificatorComponent stunModificatorComponent;
		}
		protected struct Creature
		{
			public StunModificatorComponent stunModificatorComponent;
			public MovingComponent movingComponent;
		}
		protected struct RotationCreature
		{
			public StunModificatorComponent stunModificatorComponent;
			public RotationComponent rotationComponent;
		}
		
		
		protected override void OnUpdate()
		{
			foreach (var entity in GetEntities<Modificator>())
			{
				bool isEnable = entity.stunModificatorComponent.isEnable;
				
				if(!isEnable) continue;

				float last = entity.stunModificatorComponent.last;
				float duration = entity.stunModificatorComponent.duration;
				float currentTime = Time.realtimeSinceStartup;
				if (last + duration < currentTime) isEnable = false;

				float fillAmount = 1 - (currentTime - last) / duration;

				entity.stunModificatorComponent.fillAmount = fillAmount;
				entity.stunModificatorComponent.isEnable = isEnable;
			}

			foreach (var entity in GetEntities<Creature>())
			{
				if(!entity.stunModificatorComponent.isEnable) continue;
				
				entity.movingComponent.vertical = 0;
				entity.movingComponent.horizontal = 0;
			}

			foreach (var entity in GetEntities<RotationCreature>())
			{
				bool isStunEnable = entity.stunModificatorComponent.isEnable;
				entity.rotationComponent.isEnable = !isStunEnable;
				
			}
			
		}

		
	}
}