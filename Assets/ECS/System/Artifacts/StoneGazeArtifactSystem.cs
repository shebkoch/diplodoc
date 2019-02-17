using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
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
			public MovingComponent movingComponent;
		}
		protected struct EnemyRotation
		{
			public EnemyComponent enemyComponent;
			public RotationComponent rotationComponent;
		}

		protected override void OnUpdate()
		{
			float lastUse = 0;
			bool isCasting = false;
			bool enable = false;
			float currentTime = Time.realtimeSinceStartup;
			
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				bool isCastNeeded = entity.artifactUsingComponent.isCastNeeded;
				enable = entity.cooldownComponent.canUse;
				isCasting = entity.stoneGazeArtifact.isCasting;	
				lastUse = entity.stoneGazeArtifact.lastUse;
				float duration = entity.stoneGazeArtifact.duration;

				if (lastUse + duration < currentTime) isCasting = false;
				
				if (isCastNeeded && enable)
				{
					lastUse = currentTime;
					isCasting = true;
					enable = false;
				}

			}

			
			bool isRotationEnable = true;
			if (isCasting)
			{
				isRotationEnable = false;
				foreach (Enemy entity in GetEntities<Enemy>())
				{
					entity.movingComponent.vertical = 0;
					entity.movingComponent.horizontal = 0;
				}
			}
			//TODO it can create error if anybody else disable rotation 
			foreach (EnemyRotation entity in GetEntities<EnemyRotation>())
			{
				entity.rotationComponent.isEnable = isRotationEnable;
			}
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				entity.stoneGazeArtifact.lastUse = lastUse;
				entity.stoneGazeArtifact.isCasting = isCasting;
				entity.cooldownComponent.canUse = enable;
				entity.cooldownComponent.last = lastUse;
			}
		}

	}
}