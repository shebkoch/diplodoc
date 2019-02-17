using System;
using UnityEngine;

namespace Scripts.Structures
{
	[Serializable]
	public struct MeleeWeapon
	{
		public float lastAttack;
		public float cooldown;
		public int damage;
		public Sprite sprite;
	}
}