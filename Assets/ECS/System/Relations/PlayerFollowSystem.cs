using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class PlayerFollowSystem : ComponentSystem
	{
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}
		protected struct Follower
		{
			public PlayerFollowComponent playerFollowComponent;
			public Transform transform;
			public MovingComponent movingComponent;
		}

		protected override void OnUpdate()
		{
			float3 position = new float3();
			foreach (Player entity in GetEntities<Player>())
			{
				position = entity.transform.position;
			}

			foreach (Follower entity in GetEntities<Follower>())
			{
				float3 enemyPosition = entity.transform.position;
				float offset = entity.playerFollowComponent.offset;
				bool offsetEnable = entity.playerFollowComponent.offsetEnable;
				
				float horizontal = 0;
				float vertical = 0;
				if (!offsetEnable || math.distance(position.xy, enemyPosition.xy) > offset)
				{
					float2 result = math.normalize(position.xy - enemyPosition.xy);
					horizontal = result.x;
					vertical = result.y;
				}

				entity.movingComponent.vertical = vertical;
				entity.movingComponent.horizontal = horizontal;
			}
			
		}


	}
}