using ECS.Component;
using ECS.Component.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Stats
{
	public class PlayerParametersStatSystem : ComponentSystem
	{
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public ParametersComponent parametersComponent;
		}
		protected struct Stat
		{
			public PlayerParametersStatComponent playerParametersStatComponent;
		}

		protected override void OnUpdate()
		{
			int hp = 0;
			foreach (Player entity in GetEntities<Player>()) hp = entity.parametersComponent.health;

			foreach (var entity in GetEntities<Stat>())
			{
				int last = entity.playerParametersStatComponent.lastHp;
				int lastReceived = 0;
				if (last != 0) lastReceived = last - hp;
				entity.playerParametersStatComponent.lastReceived = lastReceived;
				entity.playerParametersStatComponent.lastHp = hp;
			}
		}
	}
}