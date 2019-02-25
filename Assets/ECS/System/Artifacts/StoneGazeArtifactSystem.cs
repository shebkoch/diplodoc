using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	
	public class StoneGazeArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public StoneGazeArtifact stoneGazeArtifact;
			public ArtifactUsingComponent artifactUsingComponent;
			public CooldownComponent cooldownComponent;
		}

		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public StunModificatorComponent stunModificatorComponent;
		}

		protected override void OnUpdate()
		{
			float lastUse = 0;
			bool isCasting = false;
			bool enable = false;
			float currentTime = Time.realtimeSinceStartup;
			float duration = 0;
			float3 playerPos = new float3();
			float radius = 0;
			
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				bool isCastNeeded = entity.artifactUsingComponent.isCastNeeded;
				enable = entity.cooldownComponent.canUse;
				duration = entity.stoneGazeArtifact.duration;
				radius = entity.stoneGazeArtifact.radius;
				if (isCastNeeded && enable)
				{
					lastUse = currentTime;
					isCasting = true;
					enable = false;
				}
			}

			if (isCasting)
			{
				foreach (var entity in GetEntities<Enemy>())
				{
					entity.stunModificatorComponent.last = lastUse;
					entity.stunModificatorComponent.duration = duration;
					entity.stunModificatorComponent.isEnable = true;
					
				}
			}
			
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				entity.cooldownComponent.canUse = enable;
				if(lastUse != 0)
					entity.cooldownComponent.isReloadNeeded = true;
			}

			
		}

	}
}