using ECS.Component;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class RangedAttackSystem : ComponentSystem
	{
		protected struct Creature
		{
			public Transform transform;
			public RangedWeaponComponent rangedWeaponComponent;
			public RangedAttackComponent rangedAttackComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{
				float3 attackPos = entity.rangedAttackComponent.endPoint;
				RangedWeapon weapon = entity.rangedWeaponComponent.rangedWeapon;
				float3 position = entity.transform.position;
				bool isAttackNeed = entity.rangedAttackComponent.isAttackNeed;
				bool isWeaponEnable = entity.rangedWeaponComponent.isEnable;
				float currentTime = Time.realtimeSinceStartup;
				
				if (!isAttackNeed || !isWeaponEnable || weapon.lastAttack + weapon.cooldown > currentTime) continue;

				weapon.lastAttack = currentTime;
				weapon.bulletCount--;
				if (weapon.bulletCount == 0) isWeaponEnable = false;
				float3 direction = attackPos - position;
				float angle = math.degrees(math.atan2(direction.y, direction.x));
				float3 forward = new float3(0.0f, 0.0f, 1f);
				
				//ECS
				GameObject bullet = GameObject.Instantiate(weapon.bulletPrefab, position, quaternion.identity);
				bullet.transform.rotation = Quaternion.AngleAxis(angle, forward);
				
				float2 result = math.normalize(direction.xy);
				float horizontal = result.x;
				float vertical = result.y;

				//ECS
				var bulletMoving = bullet.GetComponent<MovingComponent>();
				bulletMoving.vertical = vertical;
				bulletMoving.horizontal = horizontal;
				bulletMoving.speed = weapon.bulletSpeed;
				
				entity.rangedWeaponComponent.rangedWeapon = weapon;
				entity.rangedWeaponComponent.isEnable = isWeaponEnable;
			}
		}
	}
}