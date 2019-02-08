using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class RotationSystem : ComponentSystem
	{
		protected struct Entity
		{
			public Transform transform;
			public MovingComponent movingComponent;
			public RotationComponent rotationComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Entity entity in GetEntities<Entity>())
			{
				float horizontal = entity.movingComponent.horizontal;
				float vertical = entity.movingComponent.vertical;
				
				float angle = math.degrees(math.atan2(vertical, horizontal));
				float3 forward = new float3(0.0f, 0.0f, 1f);
				
				entity.transform.rotation = Quaternion.AngleAxis(angle, forward);
			}
		}


	}
}