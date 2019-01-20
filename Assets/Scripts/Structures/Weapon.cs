using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Structures
{
	[System.Serializable]
	public struct Weapon
	{
		public WeaponType type;
		public GameObject bulletPrefab;
		public float attackSpeed;
		public int damage;
		public float bulletSpeed;
		public List<WeaponBooster> boosters;
	}

	public enum WeaponType
	{
		Ranged,
		Melee
	}
}