using ECS.Component;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class PlayerUseSystem : ComponentSystem
	{
		protected struct Input
		{
			public InputUseComponent inputUseComponent;
		}
		protected struct Artifact
		{
			public ArtifactUsingComponent artifactUsingComponent;
		}
		
		protected override void OnUpdate()
		{
			bool useButtonDown = false;
			foreach (Input entity in GetEntities<Input>())
			{
				useButtonDown = entity.inputUseComponent.useButtonDown;
			}
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				entity.artifactUsingComponent.isCastNeeded = useButtonDown;
			}
		}


	}
}