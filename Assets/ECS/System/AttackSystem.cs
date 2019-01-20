using ECS.Component;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class AttackSystem : ComponentSystem
	{
		protected struct Attack
		{
			public AttackComponent attack;
			public WeaponComponent weapon;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			foreach (Attack entity in GetEntities<Attack>())
			{
				bool isAttackNeeded = entity.attack.isAttackNeeded;
				if(!isAttackNeeded) continue;
				float3 endPoint = entity.attack.endPoint;
				Weapon weapon = entity.weapon.mainWeapon;
				float3 position = entity.transform.position;
				float3 direction = endPoint - position;
				float angle = math.degrees(math.atan2(direction.y, direction.x));
				float3 forward = new float3(0.0f, 0.0f, 1f);
				
				if (weapon.type == WeaponType.Ranged)
				{
					GameObject bullet = GameObject.Instantiate(weapon.bulletPrefab, position,quaternion.identity);
					bullet.transform.rotation = quaternion.AxisAngle(forward, angle); //TODO: ECS
					bullet.transform.Translate(bullet.transform.forward * weapon.bulletSpeed);
				}

				entity.attack.isAttackNeeded = false;
			}
		}


	}
}