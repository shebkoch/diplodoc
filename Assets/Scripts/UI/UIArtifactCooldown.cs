using System.Collections.Generic;
using System.Linq;
using ECS.Component;
using ECS.Component.Artifacts.Common;
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
			if (!cooldownComponent)
			{
				int id = uiArtifactCooldownComponent.id;
				ArtifactComponent artifactUsingComponent =
					FindObjectsOfType<ArtifactComponent>().FirstOrDefault(x => x.id == id);
				if (artifactUsingComponent)
					cooldownComponent = artifactUsingComponent.gameObject.GetComponent<CooldownComponent>();
				return;
			}
			
			var currentTime = Time.realtimeSinceStartup;

			float fill = 1;
			if (!cooldownComponent.canUse)
				fill = (currentTime - cooldownComponent.last) / cooldownComponent.cooldown;
			uiArtifactCooldownComponent.cooldownImage.fillAmount = fill;
		}
	}
}