using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Collections.Experimental;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class PhaseArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ArtifactUsingComponent artifactUsingComponent;
			public PhaseArtifact phaseArtifact;
			public DurationComponent durationComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public BoxCollider2D collider;
		}

		protected override void OnUpdate()
		{
			bool isTriggerChange = false;
			bool isTriggerOn = false;
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				var canUse = entity.artifactUsingComponent.canUse;
				var isActive = entity.phaseArtifact.isActive;
				bool isEnd = entity.durationComponent.isEnd;
				if (canUse)
				{
					isTriggerOn = true;
					isTriggerChange = true;
					entity.durationComponent.isStartNeeded = true;
					entity.artifactUsingComponent.canUse = false;
					isActive = true;
				}
				if(isEnd){
					isTriggerOn = false;
					isTriggerChange = true;
					isActive = false;
				}

				entity.phaseArtifact.isActive = isActive;
			}

			if (isTriggerChange)
			{
				foreach (var entity in GetEntities<Player>())
				{
					entity.collider.isTrigger = isTriggerOn;
				}
			}
		}
	}
}