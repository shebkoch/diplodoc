using ECS.Component;
using ECS.Component.Items;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System.Items
{
	public class PickUpRangedSystem : ComponentSystem
	{
		protected struct Creature
		{
			public PickUpRangedComponent pickUpRangedComponent;
			public RangedWeaponComponent rangedWeaponComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{
				bool isUsed = entity.pickUpRangedComponent.isUsed;
				RangedWeapon weapon = entity.pickUpRangedComponent.weapon;
				
				if(isUsed) continue;
				
				entity.rangedWeaponComponent.rangedWeapon = weapon;
				entity.pickUpRangedComponent.isUsed = true;
			}
		}


	}
}