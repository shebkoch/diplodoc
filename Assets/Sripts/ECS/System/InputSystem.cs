using ECS.Component;
using Unity.Entities;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace ECS.System
{
	public class InputSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			foreach (InputEntity entity in GetEntities<InputEntity>())
			{
				string horizontalAxisName = entity.inputComponent.horizontalAxisName;
				string verticalAxisName = entity.inputComponent.verticalAxisName;

				float horizontal = Input.GetAxis(horizontalAxisName);
				float vertical = Input.GetAxis(verticalAxisName);

				entity.inputComponent.horizontal = horizontal;
				entity.inputComponent.vertical = vertical;
			}
		}

		protected struct InputEntity
		{
			public InputComponent inputComponent;
		}
	}
}