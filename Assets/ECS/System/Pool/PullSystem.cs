using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Pool;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.System.Pool
{
	public class PullSystem : ComponentSystem
	{
		protected struct Pull
		{
			public PullComponent pullComponent;
			public RadiusComponent radiusComponent;
		}
		protected override void OnUpdate()
		{
			foreach (var entity in GetEntities<Pull>())
			{
				int countByTick = entity.pullComponent.countByTick;
				List<GameObject> objects = entity.pullComponent.objects;
				float3 startPos = entity.radiusComponent.startPos;
				float radius = entity.radiusComponent.radius;
				float spread = entity.radiusComponent.spread;
				
				if(objects.Count == 0) continue;
				
				int length;
				if (countByTick == 0)
					length = objects.Count;
				else
					length = countByTick;
				for (int i = 0; i < length; i++)
				{
					if(objects.Count == 0) break;
					GameObject gameObject = objects[0];
					objects.RemoveAt(0);
					gameObject.transform.position = Rand.OnCircle(radius,-spread,spread) + startPos;
					ParametersComponent parametersComponent = gameObject.GetComponent<ParametersComponent>();
					if (parametersComponent) parametersComponent.health = parametersComponent.maxHealth;
					gameObject.SetActive(true);
				}

				entity.pullComponent.objects = objects;
			}
		}
	}
}