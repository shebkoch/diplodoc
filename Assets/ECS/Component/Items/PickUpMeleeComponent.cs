using Scripts.Structures;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Items
{
	public class PickUpMeleeComponent : MonoBehaviour
	{
		public bool isUsed;
		public MeleeWeapon weapon;
	}
}