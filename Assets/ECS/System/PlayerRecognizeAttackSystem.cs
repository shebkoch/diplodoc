using System.Net;
using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class PlayerRecognizeAttackSystem : ComponentSystem
	{
		protected struct InputMouse
		{
			public InputMouseComponent inputMouse;
		}
		protected struct Player
		{
			public PlayerComponent player;
			public AttackComponent attack;
			public PlayerAttackComponent playerAttack;
		}
		protected struct MouseSetting
		{
			public MouseSettingsComponent mouseSetting;
		}

		protected override void OnUpdate()
		{
			float holdCooldown = -1;
			float lastAttackTime = -1;
			bool isAttackNeeded = false;
			float3 endPoint = new float3();
			
			foreach (MouseSetting entity in GetEntities<MouseSetting>()) 
				holdCooldown = entity.mouseSetting.holdCooldown;

			foreach (Player entity in GetEntities<Player>())
			{
				lastAttackTime = entity.playerAttack.lastAttackTime;
				isAttackNeeded = entity.attack.isAttackNeeded;
			}

			
			foreach (InputMouse entity in GetEntities<InputMouse>())
			{
				float holdTime = entity.inputMouse.holdTime;
				float startHold = entity.inputMouse.startHold;
				MouseKeyState leftState = entity.inputMouse.leftState;
				endPoint = entity.inputMouse.mousePosition;
				float nextAttackTime = startHold + math.floor(holdTime / holdCooldown);
				
				
				if (leftState == MouseKeyState.Down && lastAttackTime < nextAttackTime)
				{
					lastAttackTime = nextAttackTime;
					isAttackNeeded = true;
				}
			}

			foreach (Player entity in GetEntities<Player>())
			{
				entity.attack.isAttackNeeded = isAttackNeeded;
				entity.playerAttack.lastAttackTime = lastAttackTime;
				entity.attack.endPoint = endPoint;
			}
		}
	}
}