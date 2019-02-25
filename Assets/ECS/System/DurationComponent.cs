using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	//TODO Think about remove it
	public class DurationSystem : ComponentSystem
	{
		protected struct Duration
		{
			public DurationComponent durationComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Duration entity in GetEntities<Duration>())
			{
				bool isStartNeeded = entity.durationComponent.isStartNeeded;
				bool isEnd = entity.durationComponent.isEnd;
				float duration = entity.durationComponent.duration;
				float last = entity.durationComponent.last;
				float currentTime = Time.realtimeSinceStartup;

				if (isStartNeeded)
				{
					last = currentTime;
					entity.durationComponent.last = last;
					entity.durationComponent.isStartNeeded = false;
					entity.durationComponent.isEnd = false;
				}
				
				if (isEnd || last + duration > currentTime) continue;

				entity.durationComponent.isEnd = true;
			}
		}


	}
}