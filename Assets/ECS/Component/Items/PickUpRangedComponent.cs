using Scripts.Structures;
using Structures;
using UnityEngine;

namespace ECS.Component.Items
{
	public class PickUpRangedComponent : MonoBehaviour
	{
		public bool isUsed;
		public RangedWeapon weapon;
	}
}