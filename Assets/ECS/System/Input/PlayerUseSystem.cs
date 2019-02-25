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
			public ArtifactComponent artifactComponent;
			public ArtifactUsingComponent artifactUsingComponent;
		}
		
		protected override void OnUpdate()
		{
			bool use1ButtonDown = false;
			bool use2ButtonDown = false;
			foreach (Input entity in GetEntities<Input>())
			{
				use1ButtonDown = entity.inputUseComponent.use1ButtonDown;
				use2ButtonDown = entity.inputUseComponent.use2ButtonDown;
			}
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				byte id = entity.artifactComponent.id;
				if (id == 0)
				{
					entity.artifactUsingComponent.isCastNeeded = use1ButtonDown;	
				}
				else if(id == 1)
				{
					entity.artifactUsingComponent.isCastNeeded = use2ButtonDown;
				}
				
			}
		}


	}
}