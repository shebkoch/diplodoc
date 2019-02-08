using ECS.Component;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class MeleeAttackSystem : ComponentSystem
	{
		protected struct Creature
		{
			public MeleeAttackComponent meleeAttackComponent;
			public MeleeWeaponComponent meleeWeaponComponent;
			public AnimatorComponent animator;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{
				MeleeWeapon weapon = entity.meleeWeaponComponent.meleeWeapon;
				bool isAttackNeed = entity.meleeAttackComponent.isAttackNeed;
				float currentTime = Time.realtimeSinceStartup;
				string attackAnimation = entity.animator.attackAnimation;
				
				bool enabled = false;

				if (isAttackNeed && weapon.lastAttack + weapon.cooldown <= currentTime)
				{
					enabled = true;
					weapon.lastAttack = currentTime;
					entity.animator.animator.Play(attackAnimation);
				}

				entity.meleeWeaponComponent.meleeWeapon = weapon;
				entity.meleeAttackComponent.weaponCollider.enabled = enabled;
				
			}
		}


	}
}