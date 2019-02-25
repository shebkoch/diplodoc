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
     		public InputMovementComponent inputMovement;
            public InputMouseComponent inputMouse;
            public InputUseComponent inputUseComponent;
        }
		protected override void OnUpdate()
		{
			foreach (InputEntity entity in GetEntities<InputEntity>())
			{
				string horizontalAxisName = entity.inputMovement.horizontalAxisName;
				string verticalAxisName = entity.inputMovement.verticalAxisName;
				float holdTime = entity.inputMouse.holdTime;
				float startHold = entity.inputMouse.startHold;
				
				float horizontal = Input.GetAxis(horizontalAxisName);
				float vertical = Input.GetAxis(verticalAxisName);

				bool use1ButtonDown = Input.GetKey(KeyCode.Alpha1);
				bool use2ButtonDown = Input.GetKey(KeyCode.Alpha2);
				float3 mousePosition = Input.mousePosition;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
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
				
				entity.inputMovement.horizontal = horizontal;
				entity.inputMovement.vertical = vertical;
				entity.inputMouse.mousePosition = mousePosition;
				entity.inputMouse.leftState = leftState;
				entity.inputMouse.rightState = rightState;
				entity.inputMouse.holdTime = holdTime;
				entity.inputMouse.startHold = startHold;
				entity.inputUseComponent.use1ButtonDown = use1ButtonDown;
				entity.inputUseComponent.use2ButtonDown = use2ButtonDown;
			}
		}
	}
}