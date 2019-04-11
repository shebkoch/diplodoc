using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class SlowDownArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public SlowDownArtifact slowDownArtifact;
			public DurationComponent durationComponent;
			public ArtifactUsingComponent artifactUsingComponent;
			public CooldownComponent cooldownComponent;
		}

		private bool isStarted; //todo
		protected override void OnUpdate()
		{
			foreach (var entity in GetEntities<Artifact>())
			{
				bool canUse = entity.artifactUsingComponent.canUse;
				bool isEnd = entity.durationComponent.isEnd;
				if (canUse)
				{
					isStarted = true;
					Time.timeScale = entity.slowDownArtifact.slow;
					entity.cooldownComponent.isReloadNeeded = true;
					entity.artifactUsingComponent.canUse = false;
					entity.durationComponent.isStartNeeded = true;
				}

				if (isStarted && isEnd)
				{
					Time.timeScale = 1;
				}
				

			}
//			float radius = 0;
//			float slow = 0;
//			bool isChanged = false;
//			foreach (Artifact entity in GetEntities<Artifact>())
//			{
//				var canUse = entity.artifactUsingComponent.canUse;
//				radius = entity.radiusComponent.radius;
//				slow = entity.slowDownArtifact.slow;
//				bool isEnd = entity.durationComponent.isEnd;
//				bool active = entity.slowDownArtifact.active;
//				if (isEnd && active)
//				{
//					isChanged = true;
//					slow = -slow;
//					active = false;
//				}
//				if (canUse)
//				{
//					isChanged = true;
//					entity.durationComponent.isStartNeeded = true;
//					entity.cooldownComponent.isReloadNeeded = true;
//					active = true;
//				}
//				entity.slowDownArtifact.active = active;
//			}
//
//			if(!isChanged) return;
//			
//			foreach (var entity in GetEntities<Enemy>())
//			{
//				float distanceToPlayer = entity.playerFollowComponent.distanceToPlayer;
//				if(math.abs(distanceToPlayer) > math.abs(radius)) continue;
//
//				float speed = entity.movingComponent.speed;
//				speed += slow;
//				entity.movingComponent.speed = speed;
//			}
		}
	}
}