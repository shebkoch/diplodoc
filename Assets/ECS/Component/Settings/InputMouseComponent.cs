using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class InputMouseComponent : MonoBehaviour
	{
		public float holdTime;
		public MouseKeyState leftState;
		public float3 mousePosition;
		public MouseKeyState rightState;
		public float startHold = -1;
	}

	public enum MouseKeyState
	{
		Down,
		Up
	}
}