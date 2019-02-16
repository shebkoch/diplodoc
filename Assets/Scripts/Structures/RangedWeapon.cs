using UnityEngine;

namespace Scripts.Structures
{
	[System.Serializable]
	public struct RangedWeapon
	{
		public GameObject bulletPrefab;
		public float lastAttack;
		public float cooldown;
		public float bulletSpeed;
		public int damage;
		public int bulletCount;
	}
}