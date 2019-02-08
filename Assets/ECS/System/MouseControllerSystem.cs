using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS.System
{
	public class MouseControllerSystem : ComponentSystem
	{
		protected struct Input
		{
			public InputMouseComponent inputMouseComponent;
			public InputAttackComponent inputAttackComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public RangedAttackComponent rangedAttackComponent;
		}
		
		protected override void OnUpdate()
		{
			float3 mousePos = float3.zero;
			foreach (Input entity in GetEntities<Input>())
			{
				mousePos = entity.inputMouseComponent.mousePosition;
				MouseKeyState rightState = entity.inputMouseComponent.rightState;
				MouseKeyState leftState = entity.inputMouseComponent.leftState;

				bool rangedPress = leftState == MouseKeyState.Down;
				bool meleePress = rightState == MouseKeyState.Down;

				entity.inputAttackComponent.rangedPress = rangedPress;
				entity.inputAttackComponent.meleePress = meleePress;
			}

			foreach (Player entity in GetEntities<Player>())
			{
				entity.rangedAttackComponent.endPoint = mousePos;
			}
		}


	}
}