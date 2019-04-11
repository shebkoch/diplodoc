using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.System.Artifacts
{
	[UpdateAfter(typeof(PlayerFollowSystem))]
	public class FakePlayerFollowSystem : ComponentSystem
	{
		protected struct Fake
		{
			public FakePlayerFollowArtifact fakePlayerFollowArtifact;
			public ArtifactUsingComponent artifactUsingComponent;
			public DurationComponent durationComponent;
			public CooldownComponent cooldownComponent;
		}
		protected struct Follower
		{
			public EnemyComponent enemyComponent;
			public PlayerFollowComponent playerFollowComponent;
			public Transform transform;
			public MovingComponent movingComponent;
		}

		protected override void OnUpdate()
		{
			
			float2 min = 0;
			float2 max = 0;
			bool isEnable = false;
			foreach (Fake entity in GetEntities<Fake>())
			{
				min = entity.fakePlayerFollowArtifact.min;
				max = entity.fakePlayerFollowArtifact.max;
				if (entity.artifactUsingComponent.canUse)
				{
					entity.durationComponent.isStartNeeded = true;
					entity.cooldownComponent.isReloadNeeded = true;
					entity.artifactUsingComponent.canUse = false;
				}
				isEnable = !entity.durationComponent.isEnd;
			}

			if(!isEnable) return;
			
			foreach (var entity in GetEntities<Follower>())
			{
				float3 enemyPosition = entity.transform.position;
				float horizontal = 0;
				float vertical = 0;
				
				float2 result = math.normalize(new float2(Random.Range(min.x,max.x), Random.Range(min.y,max.y)) - enemyPosition.xy);
				horizontal = result.x;
				vertical = result.y;
				
				entity.movingComponent.vertical = vertical;
				entity.movingComponent.horizontal = horizontal;
			}

		}
	}
}