using ECS.Component;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.UI
{
	public class UIArtifactCooldown : MonoBehaviour
	{
		public CooldownComponent cooldownComponent;
		public UIArtifactCooldownComponent uiArtifactCooldownComponent;

		private void Update()
		{
			var currentTime = Time.realtimeSinceStartup;

			float fill = 1;
			if (!cooldownComponent.canUse)
				fill = (currentTime - cooldownComponent.last) / cooldownComponent.cooldown;
			uiArtifactCooldownComponent.cooldownImage.fillAmount = fill;
		}
	}
}