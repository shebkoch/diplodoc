using ECS.Component;
using ECS.Component.Attack;
using ECS.Component.Attack.PreAttack;
using Scripts.Structures;
using Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.PreAttack
{
	public class AroundShotPreAttackSystem : ComponentSystem
	{
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}
		protected struct PreAttack
		{
			public PreAttackComponent preAttackComponent;
		}

		protected override void OnUpdate()
		{
			float3 position = new float3();
			foreach (var entity in GetEntities<Player>()) position = entity.transform.position;
			
			foreach (PreAttack entity in GetEntities<PreAttack>())
			{
				bool isAttacked = entity.preAttackComponent.isAttacked;
				
				if(!isAttacked) continue;

				RangedWeapon weapon = entity.preAttackComponent.weapon;
				
				if(weapon.preAttack != Structures.PreAttack.AroundShot) continue;
				
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if(i == 0 && j == 0) continue;
						GameObject bulletInstance = GameObject.Instantiate(weapon.bulletPrefab, position, quaternion.identity);
						MovingComponent movingComponent = bulletInstance.GetComponent<MovingComponent>();
						movingComponent.vertical = i;
						movingComponent.horizontal = j;
					}
				}

				entity.preAttackComponent.isAttacked = false;
			}

		}
	}
}