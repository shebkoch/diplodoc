using System;
using ECS.Component;
using ECS.Component.Artifacts;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
	public class TeleportArtifactSystem : ComponentSystem
	{
		protected struct Entity
		{
			public TeleportArtifact teleportArtifact;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public Transform transform;
		}
		protected override void OnUpdate()
		{
			float3 location = new float3();
			bool active = false;
			foreach (var entity in GetEntities<Entity>())
			{
				active = entity.teleportArtifact.active;
				if(!active) return;
				location = entity.teleportArtifact.location;

				entity.teleportArtifact.active = false;
			}
			if(!active) return;
			foreach (var entity in GetEntities<Player>()){
				entity.transform.position = location;
			}
		}
	}
}