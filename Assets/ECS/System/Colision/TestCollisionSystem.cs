using ECS.Component;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
	public class TestCollisionSystem : ComponentSystem
	{
		protected struct Entity
		{
			public TestCollisionComponent collisionComponent;
		}
		protected struct Map
		{
			public MapComponent mapComponent;
		}
		//todo
		const int size =3;
		protected override void OnUpdate()
		{
			entity4[,] map = null;
			foreach (Map entity in GetEntities<Map>())
			{
				map = entity.mapComponent.map;
			}
			
			foreach (Entity entity in GetEntities<Entity>())
			{
				int3 pos = entity.collisionComponent.position;
				for (int i = -size; i < size; i++)
				{
					pos[1] = 1;
					for (int j = -size; j < size; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							entity4 elems = map[pos.x + i, pos.y + j];
							foreach (var elem in elems.Get())
							{
								if (elem.Index != 0)
								{
									EntityManager.GetComponentData<Transform>()
									entity.collisionComponent.collisions.Add(elem);
								}
							}
						}
					}
				}
			}
		}


	}
}