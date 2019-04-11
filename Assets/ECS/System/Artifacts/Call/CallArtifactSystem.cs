using ECS.Component;
using ECS.Component.Artifacts.Call;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts.Call
{
	
	public class CallArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public CallArtifactComponent callArtifactComponent;
		}
		protected override void OnUpdate()
		{
			foreach (var entity in GetEntities<Artifact>())
			{
				bool isCallNeeded = entity.callArtifactComponent.isCallNeeded;
				if(!isCallNeeded) continue;

				int count = entity.callArtifactComponent.count;
				GameObject gameObject = entity.callArtifactComponent.calling;
				float3 position = entity.callArtifactComponent.position;
				for (int i = 0; i < count; i++)
				{
					GameObject instance = GameObject.Instantiate(gameObject, position,Quaternion.identity);
					DurationComponent component = instance.GetComponent<DurationComponent>();
					if (component) component.isStartNeeded = true;
				}
				entity.callArtifactComponent.isCallNeeded = false;
			}
		}
	}
}