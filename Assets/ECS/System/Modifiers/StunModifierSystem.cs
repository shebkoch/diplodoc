using System;
using ECS.Component;
using ECS.Component.Modifiers;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	[UpdateAfter(typeof(ModifierSystem))]
	public class StunModifierSystem : ComponentSystem
	{
		protected struct Enemy
		{
			public StunModifier stunModifier;
			public MovingComponent movingComponent;
		}
		protected struct Modifier
		{
			public ModifierComponent modifierComponent;
		}
		
		
		protected override void OnUpdate()
		{
			ModifierState modifierState = ModifierState.Inactive;
			foreach (var entity in GetEntities<Modifier>()) 
				modifierState = entity.modifierComponent.modifierState;
			foreach (Enemy entity in GetEntities<Enemy>())
			{
				float speed = entity.movingComponent.speed;
				
				switch (modifierState)
				{
					case ModifierState.Before:
						entity.stunModifier.keepSpeed = speed;
						break;
					case ModifierState.Active:
						entity.movingComponent.speed = 0;
						break;
					case ModifierState.After:
						entity.movingComponent.speed = entity.stunModifier.keepSpeed;
						break;
				}
			}
		}
	}
}