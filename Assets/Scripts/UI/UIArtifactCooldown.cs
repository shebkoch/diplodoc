using ECS.Component;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace.UI
{
	public class UIArtifactCooldown : MonoBehaviour
	{
		public UIArtifactCooldownComponent uiArtifactCooldownComponent;
		public CooldownComponent cooldownComponent;

		private void Update()
		{
		
			float currentTime = Time.realtimeSinceStartup;
			
			float fill= 1;
			if(!cooldownComponent.canUse)
				fill = (currentTime - cooldownComponent.last) / cooldownComponent.cooldown;
			uiArtifactCooldownComponent.cooldownImage.fillAmount = fill;
		}
	}
}