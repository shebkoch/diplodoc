using ECS.Component;
using Unity.Entities;
namespace ECS.System
{
	public class PlayerInputSystem :  ComponentSystem
	{
		protected struct PlayerMoving
		{
			public MovingComponent moving;
			public PlayerComponent player;
		}

		protected struct Input
		{
			public InputComponent input;
		}
		
		protected override void OnUpdate()
		{
			float horizontal = 0;
			float vertical = 0;
			foreach (Input entity in GetEntities<Input>())
			{
				horizontal = entity.input.horizontal;
				vertical = entity.input.vertical;
			}
			foreach (var entity in GetEntities<PlayerMoving>())
			{
				entity.moving.horizontal = horizontal;
				entity.moving.vertical = vertical;
			}
		}
	}
}