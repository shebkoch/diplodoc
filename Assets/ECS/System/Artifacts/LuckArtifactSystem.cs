using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class LuckArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public LuckArtifact luckArtifact;
		}

		protected struct ChanceArtifacts
		{
			public ArtifactComponent artifactComponent;
			public ChanceArtifactComponent chanceArtifactComponent;
		}

		protected override void OnUpdate()
		{
			int chanceAdd = 0;
			foreach (Artifact entity in GetEntities<Artifact>()) 
				chanceAdd = entity.luckArtifact.chance;
			
			foreach (var entity in GetEntities<ChanceArtifacts>())
			{
				int chance = entity.chanceArtifactComponent.chance;

				chance += chanceAdd;

				entity.chanceArtifactComponent.chance = chance;
			}
			Enabled = false;
		}
	}
}