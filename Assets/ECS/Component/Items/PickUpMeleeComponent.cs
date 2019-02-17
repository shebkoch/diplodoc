using Scripts.Structures;
using UnityEngine;

namespace ECS.Component.Items
{
	public class PickUpMeleeComponent : MonoBehaviour
	{
		public bool isUsed;
		public MeleeWeapon weapon;
		public GameObject weaponObject;
	}
}