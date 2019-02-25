using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts
{
	[DisableAutoCreation]
	public class ArthurStoneSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ArthurStoneArtifact arthurStoneArtifact;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			GameObject marker = null;
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				var random = Rand.GetRandom();
				float maxDistance = entity.arthurStoneArtifact.maxDistance;
				float minDistance = entity.arthurStoneArtifact.minDistance;
				marker = entity.arthurStoneArtifact.marker;
				float2 pos = random.NextFloat2(minDistance, maxDistance);
				GameObject.Instantiate(entity.arthurStoneArtifact.sword, new float3(pos,0), quaternion.identity);
				entity.arthurStoneArtifact.swordPosition = pos;
			}

			foreach (var entity in GetEntities<Player>())
			{
				GameObject.Instantiate(marker, entity.transform);
			}
			Enabled = false;
		}
	}
}