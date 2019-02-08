using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class PlayerAttackInputSystem : ComponentSystem
	{
		protected struct PlayerRanged
		{
			public PlayerComponent playerComponent;
			public RangedAttackComponent rangedAttackComponent;
		}
		protected struct PlayerMelee
		{
			public PlayerComponent playerComponent;
			public MeleeAttackComponent meleeAttackComponent;
		}
		protected struct Input
		{
			public InputAttackComponent inputAttackComponent;
		}

		protected override void OnUpdate()
		{
			bool rangedPress = false;
			bool meleePress = false;
			foreach (Input entity in GetEntities<Input>())
			{
				rangedPress = entity.inputAttackComponent.rangedPress;
				meleePress = entity.inputAttackComponent.meleePress;
			}
			
			foreach (PlayerRanged entity in GetEntities<PlayerRanged>())
			{
				entity.rangedAttackComponent.isAttackNeed = rangedPress;
			}

			foreach (PlayerMelee entity in GetEntities<PlayerMelee>())
			{
				entity.meleeAttackComponent.isAttackNeed = meleePress;
			}
		}


	}
}