using ECS.Component;
using ECS.Component.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
	public class UIBullet : MonoBehaviour
	{
		public UIBulletComponent bulletComponent;

		private Text bulletText;
		public RangedWeaponComponent rangedWeaponComponent;

		private void Start()
		{
			bulletText = bulletComponent.bulletCountText;
		}

		private void Update()
		{
			bulletText.text = rangedWeaponComponent.rangedWeapon.bulletCount.ToString();
		}
	}
}