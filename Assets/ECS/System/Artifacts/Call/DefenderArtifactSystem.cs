using ECS.Component;
using ECS.Component.Artifacts.Call;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts.Call
{
	public class DefenderArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ArtifactUsingComponent artifactUsingComponent;
			public DefenderArtifact defenderArtifact;
			public CooldownComponent cooldownComponent;
		}
		public struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			float3 position = 0;
			foreach (var entity in GetEntities<Player>()) position = entity.transform.position;
			
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				bool enable = entity.artifactUsingComponent.canUse;
				if (enable)
				{
					float defenderArtifactDuration = entity.defenderArtifact.duration;
					entity.cooldownComponent.isReloadNeeded = true;
					for (int i = 0; i < 3; i++)
					{
						GameObject defender = GameObject.Instantiate(entity.defenderArtifact.defender, position,Quaternion.identity);
						var cooldownComponent = defender.GetComponent<CooldownComponent>();
						cooldownComponent.cooldown = defenderArtifactDuration;
						cooldownComponent.isReloadNeeded = true;
					}
				}
				
				entity.artifactUsingComponent.canUse = false;
			}
		}
	}
}