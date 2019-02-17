using UnityEngine;

namespace ECS.Component
{
	public class AnimatorComponent : MonoBehaviour
	{
		public Animator animator;
		public string attackAnimation;
		public bool isAnimationNeeded;
	}
}