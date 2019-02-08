using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class MovingSystem :  ComponentSystem
	{
		protected struct Moving
		{
			public MovingComponent moving;
			public Transform transform;
		}
		
		protected override void OnUpdate()
		{
			foreach (var entity in GetEntities<Moving>())
			{
				float horizontal = entity.moving.horizontal;
				float vertical = entity.moving.vertical;
				float speed = entity.moving.speed;
				float3 position = entity.transform.position;
				
				float3 movePosition = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

				position += movePosition;
				
				entity.transform.position = position;

				//entity.transform.Translate(movePosition);
			}
		}
	}
}