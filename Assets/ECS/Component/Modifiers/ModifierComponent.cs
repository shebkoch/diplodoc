using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ECS.Component.Modifiers
{
	public class ModifierComponent : MonoBehaviour
	{
		public ModifierState modifierState = ModifierState.Inactive;
		public bool needActive;
	}
	public enum ModifierState
	{
		Before, Active, After, Inactive
	}
	
}