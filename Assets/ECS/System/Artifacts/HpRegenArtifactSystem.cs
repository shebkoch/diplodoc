using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class HpRegenArtifactSystem : ComponentSystem
	{
		protected struct Entity
		{
			public ArtifactUsingComponent artifactUsingComponent;
			public HpRegenArtifact hpRegenArtifact;
			public CooldownComponent cooldownComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public ParametersComponent parametersComponent;
		}

		protected override void OnUpdate()
		{
			bool enable = false;
			foreach (Entity entity in GetEntities<Entity>())
			{
				bool isCastNeeded = entity.artifactUsingComponent.isCastNeeded;
				if(!isCastNeeded) continue;
				enable = entity.cooldownComponent.canUse;
				if (enable)
				{
					entity.cooldownComponent.isReloadNeeded = true;
				}
			}
			if(!enable) return;
			foreach (var entity in GetEntities<Player>())
			{
				entity.parametersComponent.health = entity.parametersComponent.maxHealth;
			}
		}
	}
}