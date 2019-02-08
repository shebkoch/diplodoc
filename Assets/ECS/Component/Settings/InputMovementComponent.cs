using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class InputMovementComponent : MonoBehaviour
	{
		public float horizontal;
		public string horizontalAxisName;
		public float vertical;
		public string verticalAxisName;
	}
}