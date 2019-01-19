using System.Collections.Generic;

namespace Sripts.Structures
{
	[System.Serializable]
	public struct Weapon
	{
		public WeaponType type;
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