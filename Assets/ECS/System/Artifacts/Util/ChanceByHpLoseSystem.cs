using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Stats;
using ECS.System.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System.Artifacts
{
	[UpdateAfter(typeof(PlayerParametersStatSystem))]
	public class ChanceByHpLoseSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ChanceArtifactComponent chanceArtifactComponent;
			public ChanceByHpLoseComponent chanceByHpLoseComponent;
		}
		protected struct Stat
		{
			public PlayerParametersStatComponent playerParametersStatComponent;
		}
		
		protected override void OnUpdate()
		{
			Random random = Rand.GetRandom();
			int lastReceived = 0;
			
			foreach (Stat entity in GetEntities<Stat>())
				lastReceived = entity.playerParametersStatComponent.lastReceived;

			foreach (var entity in GetEntities<Artifact>())
			{
				int chance = entity.chanceArtifactComponent.chance;
				bool isActivate = false;
				for (int i = 0; i < lastReceived; i++)
				{
					int randInt = random.NextInt(100);
					isActivate = randInt < chance;
					if(isActivate) break;
				}

				entity.chanceByHpLoseComponent.isActivate = isActivate;
			}
		}
	}
}