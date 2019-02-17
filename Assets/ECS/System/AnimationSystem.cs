using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class AnimationSystem : ComponentSystem
	{
		protected struct Animation
		{
			public AnimatorComponent animatorComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Animation entity in GetEntities<Animation>())
			{
				bool isAnimationNeeded = entity.animatorComponent.isAnimationNeeded;
				Animator animator = entity.animatorComponent.animator;
				string animatorState = entity.animatorComponent.attackAnimation;
				
				if (isAnimationNeeded)
				{
					//ECS
					isAnimationNeeded = false;
					animator.Play(animatorState);	
				}

				entity.animatorComponent.isAnimationNeeded = isAnimationNeeded;
			}
		}
	}
}