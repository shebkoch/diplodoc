using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace ECS.System
{
	public class InputSystem : ComponentSystem
	{
		protected struct InputEntity
     	{
     		public InputComponent input;
            public InputMouseComponent inputMouse;
        }
		protected override void OnUpdate()
		{
			foreach (InputEntity entity in GetEntities<InputEntity>())
			{
				string horizontalAxisName = entity.input.horizontalAxisName;
				string verticalAxisName = entity.input.verticalAxisName;
				float holdTime = entity.inputMouse.holdTime;
				float startHold = entity.inputMouse.startHold;
				
				float horizontal = Input.GetAxis(horizontalAxisName);
				float vertical = Input.GetAxis(verticalAxisName);
				Debug.Assert(Camera.main != null, (string) "Camera.main != null");
				float3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePosition.z = 0;
				bool leftDown = Input.GetMouseButton(0);
				bool rightDown = Input.GetMouseButton(1);
				MouseKeyState leftState = leftDown ? MouseKeyState.Down : MouseKeyState.Up;
				MouseKeyState rightState = rightDown ? MouseKeyState.Down : MouseKeyState.Up;
				if (leftDown && startHold <= 0) startHold = Time.realtimeSinceStartup;
				if (leftDown && startHold >= 0) holdTime = Time.realtimeSinceStartup - startHold;
				if (!leftDown)
				{
					holdTime = -1;
					startHold = -1;
				}
				
				entity.input.horizontal = horizontal;
				entity.input.vertical = vertical;
				entity.inputMouse.mousePosition = mousePosition;
				entity.inputMouse.leftState = leftState;
				entity.inputMouse.rightState = rightState;
				entity.inputMouse.holdTime = holdTime;
				entity.inputMouse.startHold = startHold;
			}
		}

		
	}
}