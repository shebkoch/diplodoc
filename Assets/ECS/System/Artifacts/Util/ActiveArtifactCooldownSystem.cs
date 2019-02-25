using ECS.Component;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class ActiveArtifactCooldownSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ArtifactUsingComponent artifactUsingComponent;
			public CooldownComponent cooldownComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				bool isCastNeeded = entity.artifactUsingComponent.isCastNeeded;
				if(!isCastNeeded) continue;
				bool enable = entity.cooldownComponent.canUse;
				if (enable) entity.artifactUsingComponent.canUse = true;
			}
		}
	}
}