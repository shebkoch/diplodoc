using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	[DisableAutoCreation]
	public class SlowDownArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public SlowDownArtifact slowDownArtifact;
			public RadiusComponent radiusComponent;
			public DurationComponent durationComponent;
			public ArtifactUsingComponent artifactUsingComponent;
			public CooldownComponent cooldownComponent;
		}
		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public MovingComponent movingComponent;
			public PlayerFollowComponent playerFollowComponent;
		} 
		protected override void OnUpdate()
		{
			bool canUse = false;
			float radius = 0;
			float slow = 0;
			bool isChanged = false;
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				canUse = entity.artifactUsingComponent.canUse;
				radius = entity.radiusComponent.radius;
				slow = entity.slowDownArtifact.slow;
				bool isEnd = entity.durationComponent.isEnd;
				bool active = entity.slowDownArtifact.active;
				if (isEnd && active)
				{
					isChanged = true;
					slow = -slow;
					active = false;
				}
				if (canUse)
				{
					isChanged = true;
					entity.durationComponent.isStartNeeded = true;
					entity.cooldownComponent.isReloadNeeded = true;
					active = true;
				}
				entity.slowDownArtifact.active = active;
			}

			if(!isChanged) return;
			
			foreach (var entity in GetEntities<Enemy>())
			{
				float distanceToPlayer = entity.playerFollowComponent.distanceToPlayer;
				if(math.abs(distanceToPlayer) > math.abs(radius)) continue;

				float speed = entity.movingComponent.speed;
				speed += slow;
				entity.movingComponent.speed = speed;
			}
		}
	}
}