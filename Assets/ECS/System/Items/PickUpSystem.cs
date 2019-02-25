using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Items;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	//ECS
	public class PickUpSystem : ComponentSystem
	{
		protected struct Ranged
		{
			public PickUpRangedComponent pickUpRangedComponent;
			public PickUpComponent pickUpComponent;
			public DeathComponent deathComponent;
		}
		protected struct Melee
		{
			public PickUpMeleeComponent pickUpMeleeComponent;
			public PickUpComponent pickUpComponent;		
			public DeathComponent deathComponent;
		}
		
		protected override void OnUpdate()
		{
			foreach (Ranged entity in GetEntities<Ranged>())
			{
				GameObject picker = entity.pickUpComponent.picker;
				if(picker == null) continue;

				RangedWeapon rangedWeapon = entity.pickUpRangedComponent.weapon;
				var pickUpRangedComponent = picker.GetComponent<PickUpRangedComponent>();
				pickUpRangedComponent.weapon = rangedWeapon;
				pickUpRangedComponent.isUsed = false;
				entity.deathComponent.isDeathNeed = true;
			}
			foreach (Melee entity in GetEntities<Melee>())
			{
				GameObject picker = entity.pickUpComponent.picker;
				if(picker == null) continue;

				MeleeWeapon rangedWeapon = entity.pickUpMeleeComponent.weapon;
				var pickUpMeleeComponent = picker.GetComponent<PickUpMeleeComponent>();
				pickUpMeleeComponent.weaponObject.GetComponent<SpriteRenderer>().sprite =
					rangedWeapon.sprite;
				pickUpMeleeComponent.weapon = rangedWeapon;
				pickUpMeleeComponent.isUsed = false;
				entity.deathComponent.isDeathNeed = true;
			}
		}


	}
}