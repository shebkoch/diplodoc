using ECS.Component;
using ECS.Component.Attack;
using ECS.Component.Items;
using Scripts.Structures;
using Structures;
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
				entity.rangedWeaponComponent.isEnable = true;
				entity.pickUpRangedComponent.isUsed = true;
			}
		}


	}
}