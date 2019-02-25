using System;
using ECS.Component;
using ECS.Component.Artifacts;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

namespace ECS.System.Artifacts
{
	public class HasteArtifactSystem : ComponentSystem
	{
		protected struct Artifact
		{
			public ChanceByHpLoseComponent chanceByHpLoseComponent;
			public HasteArtifact hasteArtifact;
			public CooldownComponent cooldownComponent;
		}
		protected struct Camera
		{
			public CameraComponent cameraComponent;
			public MovingComponent movingComponent;
		}
		protected struct Player
		{
			public PlayerComponent playerComponent;
			public MovingComponent movingComponent;
		}
		protected override void OnUpdate()
		{
			bool isActive = false;
			float hasteSpeed = 0;
			bool isSpeedChange = false;
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				isActive = entity.hasteArtifact.isActive;
				hasteSpeed = entity.hasteArtifact.speed;
				bool chanceActive = entity.chanceByHpLoseComponent.isActivate;
				bool isReloadNeeded = false;
				if (isActive)
				{
					bool isEnd = entity.cooldownComponent.canUse;
					if (isEnd)
					{
						hasteSpeed = -hasteSpeed;
						isActive = false;
						isSpeedChange = true;
					}
				}
				else if(chanceActive)
				{
					isActive = true;
					isReloadNeeded = true;
					isSpeedChange = true;
				}

				entity.cooldownComponent.isReloadNeeded = isReloadNeeded;
				entity.hasteArtifact.isActive = isActive;
			}

			if (!isSpeedChange) return;

			foreach (var entity in GetEntities<Camera>())
			{
				float speed = entity.movingComponent.speed;
				speed += hasteSpeed;
				entity.movingComponent.speed = speed;
			}
			foreach (var entity in GetEntities<Player>())
			{
				float speed = entity.movingComponent.speed;
				speed += hasteSpeed;
				entity.movingComponent.speed = speed;
			}
		}
	}
}