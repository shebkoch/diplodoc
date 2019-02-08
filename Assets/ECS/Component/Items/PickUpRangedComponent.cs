using Scripts.Structures;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Items
{
	public class PickUpRangedComponent : MonoBehaviour
	{
		public bool isUsed;
		public RangedWeapon weapon;
	}
}