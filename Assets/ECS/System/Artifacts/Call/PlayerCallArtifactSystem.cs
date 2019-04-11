using ECS.Component;
using ECS.Component.Artifacts.Call;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts.Call
{
	public class PlayerCallArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ArtifactUsingComponent artifactUsingComponent;
			public PlayerCallArtifactComponent playerCallArtifactComponent;
			public CallArtifactComponent callArtifactComponent;
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
					entity.cooldownComponent.isReloadNeeded = true;
					entity.callArtifactComponent.isCallNeeded = true;
					entity.callArtifactComponent.position = position;
				}

				
				entity.artifactUsingComponent.canUse = false;
			}
		}
	}
}