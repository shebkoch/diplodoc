using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class CreatureTransformSystem : ComponentSystem
	{
		protected struct Creature
		{
			public CreatureTransformComponent creatureTransformComponent;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			foreach (Creature entity in GetEntities<Creature>())
			{

			}
		}


	}
}