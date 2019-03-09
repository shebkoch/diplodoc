using System;
using ECS.Component;
using ECS.Component.Modifiers;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	public class ModifierSystem : ComponentSystem
	{
		protected struct Modifier
		{
			public ModifierComponent modifierComponent;
			public DurationComponent durationComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Modifier entity in GetEntities<Modifier>())
			{
				ModifierState state = entity.modifierComponent.modifierState;
				bool isEnd = entity.durationComponent.isEnd;
				bool activeNeed = entity.modifierComponent.needActive;
				bool isStartDuration = false;
				switch (state)
				{
					case ModifierState.Before:
						state = ModifierState.Active;
						break;
					case ModifierState.Active:
					{
						if (isEnd) state = ModifierState.After;
						break;
					}
					case ModifierState.After:
						state = ModifierState.Inactive;
						break;
					case ModifierState.Inactive:
					{
						if (activeNeed)
						{
							state = ModifierState.Before;
							isStartDuration = true;
							entity.modifierComponent.needActive = false;
						}
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}

				if (isStartDuration)
					entity.durationComponent.isStartNeeded = true;
				entity.modifierComponent.modifierState = state;
			}
		}
	}
}