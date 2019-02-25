using System;
using System.Collections.Generic;
using DefaultNamespace;
using ECS.Component;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECS.System
{
	
	public class StartArtifactDistributionSystem : ComponentSystem
	{
		protected struct Pool
		{
			public ArtifactsPoolComponent artifactsPoolComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Pool entity in GetEntities<Pool>())
			{
				List<GameObject> activeArtifacts = entity.artifactsPoolComponent.activePool;
				List<GameObject> passiveArtifacts = entity.artifactsPoolComponent.passivePool;
				int passiveCount = entity.artifactsPoolComponent.passiveCount;
				int activeCount = entity.artifactsPoolComponent.activeCount;
				Random random = Rand.GetRandom();
				List<GameObject> active = new List<GameObject>();
				List<GameObject> passive = new List<GameObject>();
				
				for (byte i = 0; i < passiveCount; i++)
				{	
					int randId = random.NextInt(passiveArtifacts.Count);
					GameObject gameObject = GameObject.Instantiate(passiveArtifacts[randId]);
					passiveArtifacts.RemoveAt(randId);
					gameObject.GetComponent<ArtifactComponent>().id = i;
					passive.Add(gameObject);
				}
				
				for (byte i = 0; i < activeCount; i++)
				{
					int randId = random.NextInt(activeArtifacts.Count);
					GameObject gameObject = GameObject.Instantiate(activeArtifacts[randId]);
					activeArtifacts.RemoveAt(randId);
					gameObject.GetComponent<ArtifactComponent>().id = i;
					active.Add(gameObject);
				}

				entity.artifactsPoolComponent.active = active;
				entity.artifactsPoolComponent.passive = passive;
			}
			Enabled = false;
		}
	}
}