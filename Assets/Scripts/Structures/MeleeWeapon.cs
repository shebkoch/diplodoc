using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Structures
{
	[System.Serializable]
	public struct MeleeWeapon
	{
		public float lastAttack;
		public float cooldown;
		public int damage;
	}
}