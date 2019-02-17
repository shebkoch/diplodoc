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
				bool isAnimationNeeded = entity.animator.isAnimationNeeded;				
				bool enabled = false;

				if (isAttackNeed && weapon.lastAttack + weapon.cooldown <= currentTime)
				{
					enabled = true;
					weapon.lastAttack = currentTime;
					isAnimationNeeded = true;
				}

				entity.meleeWeaponComponent.meleeWeapon = weapon;
				entity.meleeAttackComponent.weaponCollider.enabled = enabled;
				entity.animator.isAnimationNeeded = isAnimationNeeded;
			}
		}


	}
}