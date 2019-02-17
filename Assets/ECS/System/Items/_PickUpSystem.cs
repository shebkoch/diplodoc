using System.Collections.Generic;
using ECS.Component;
using ECS.Component.Items;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	//ECS
	public class _PickUpSystem : ComponentSystem
	{
		protected struct Ranged
		{
			public CollisionComponent collisionComponent;
			public PickUpRangedComponent pickUpRangedComponent;
			public RangedWeaponComponent rangedWeaponComponent;
		}
		protected struct Melee
		{
			public CollisionComponent collisionComponent;
			public PickUpMeleeComponent pickUpMeleeComponent;
			public MeleeWeaponComponent meleeWeaponComponent;
		}
		

		protected override void OnUpdate()
		{
			foreach (Ranged entity in GetEntities<Ranged>())
			{
				List<CollisionComponent> keys = new List<CollisionComponent>();
				foreach (var collision in entity.collisionComponent.collisions)
				{
					var pickUpRanged = collision.Key.GetComponent<PickUpRangedComponent>();
					if(!pickUpRanged) continue;
					
					pickUpRanged.gameObject.GetComponent<ParametersComponent>().health--;
					entity.pickUpRangedComponent.weapon = pickUpRanged.weapon;
					entity.pickUpRangedComponent.isUsed = false;
					keys.Add(collision.Key);
				}
				keys.ForEach(x=>entity.collisionComponent.collisions.Remove(x));
			}
			foreach (Melee entity in GetEntities<Melee>())
			{
				List<CollisionComponent> keys = new List<CollisionComponent>();
				foreach (var collision in entity.collisionComponent.collisions)
				{
					var pickUpMelee = collision.Key.GetComponent<PickUpMeleeComponent>();
					if(!pickUpMelee) continue;

					pickUpMelee.gameObject.GetComponent<ParametersComponent>().health--;
					
					entity.pickUpMeleeComponent.weapon = pickUpMelee.weapon;
					entity.pickUpMeleeComponent.weaponObject.
							GetComponent<SpriteRenderer>().sprite = pickUpMelee.weapon.sprite;
					entity.pickUpMeleeComponent.isUsed = false;
					
					keys.Add(collision.Key);
				}
				keys.ForEach(x=>entity.collisionComponent.collisions.Remove(x));
			}
		}


	}
}