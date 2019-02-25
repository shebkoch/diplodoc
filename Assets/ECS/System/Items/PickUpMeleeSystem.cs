using ECS.Component;
using ECS.Component.Items;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Items
{
	public class PickUpMeleeSystem : ComponentSystem
	{
		protected struct Creature
		{
			public PickUpMeleeComponent pickUpMeleeComponent;
			public MeleeWeaponComponent meleeWeaponComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{
				bool isUsed = entity.pickUpMeleeComponent.isUsed;
				MeleeWeapon weapon = entity.pickUpMeleeComponent.weapon;
				
				if(isUsed) continue;

				entity.meleeWeaponComponent.meleeWeapon = weapon;
				entity.pickUpMeleeComponent.isUsed = true;
			}
		}
	}
}