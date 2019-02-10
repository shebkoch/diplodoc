using ECS.Component;
using Scripts.Structures;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
	[DisableAutoCreation]
	public class MapRoundSystem : ComponentSystem
	{
		protected struct Collision
		{
			public Transform transform;
			public TestCollisionComponent testCollisionComponent;
		}
		protected struct Map
		{
			public MapComponent mapComponent;
		}

		protected override void OnUpdate()
		{
			entity4[,] map = null;
			foreach (Map entity in GetEntities<Map>())
			{
				map = entity.mapComponent.map;
			} 
			foreach (Collision entity in GetEntities<Collision>())
			{
				float3 pos = entity.transform.position;
				pos = math.round(pos);
 
				int3 roundPos = new int3(pos) + 500;
				Entity colEntity = entity.transform.gameObject.GetComponent<GameObjectEntity>().Entity;

				entity.testCollisionComponent.position = roundPos;
				map[roundPos.x, roundPos.y].SetAny(colEntity);
			}
			
			foreach (Map entity in GetEntities<Map>())
			{
				entity.mapComponent.map = map;
			} 
		}


	}
}