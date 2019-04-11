using ECS.Component;
using ECS.Component.Artifacts.Call;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Artifacts.Call
{
	public class DefenderDieSystem : ComponentSystem
	{
		protected struct Defender
		{
			public PlayerDefenderComponent playerDefenderComponent;
			public DurationComponent durationComponent;
			public DeathComponent deathComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Defender entity in GetEntities<Defender>())
			{
				if (entity.durationComponent.isEnd)
					entity.deathComponent.isDeathNeed = true;
			}
		}
	}
}