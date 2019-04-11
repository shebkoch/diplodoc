using Scripts.Structures;
using Structures;
using UnityEngine;

namespace ECS.Component.Attack
{
	public class PreAttackComponent : MonoBehaviour
	{
		public bool isAttacked;
		public RangedWeapon weapon;
	}
}