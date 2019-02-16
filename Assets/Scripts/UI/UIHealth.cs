using ECS.Component;
using ECS.Component.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
	public class UIHealth : MonoBehaviour
	{
		public UIHealthComponent uiHealthComponent;
		public ParametersComponent playerParameters;
		private float maxHealth;
		private Image image;
		private void Start()
		{
			maxHealth = playerParameters.maxHealth;
			image = uiHealthComponent.image;
		}

		private void Update()
		{
			image.fillAmount = playerParameters.health / maxHealth;
		}
	}
}