using ECS.Component;
using ECS.Component.Artifacts;
using ECS.Component.Artifacts.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
    public class FrontTeleportArtifactSystem : ComponentSystem
    {
        protected struct Entity
        {
            public ArtifactUsingComponent artifactUsingComponent;
            public FrontTeleportArtifact frontTeleportArtifactSystem;
            public TeleportArtifact teleportArtifact;
            public CooldownComponent cooldownComponent;
        }
        protected struct Camera
        {
            public CameraComponent cameraComponent;
            public Transform transform;
        }
        protected struct Player
        {
            public PlayerComponent playerComponent;
            public Transform transform;
        }

        protected override void OnUpdate()
        {
            float3 position = new float3();
            float3 up = new float3();
            foreach (var entity in GetEntities<Player>())
            {
                position = entity.transform.position;
                up = entity.transform.right;
            }

            float3 location = new float3();
            bool canUse = false;
            foreach (var entity in GetEntities<Entity>())
            {
                canUse = entity.artifactUsingComponent.canUse;
                if(!canUse) continue;

                float distance = entity.frontTeleportArtifactSystem.distance;
                
                location = position + new float3(up * distance);
                                  
                entity.cooldownComponent.isReloadNeeded = true;
                entity.artifactUsingComponent.canUse = false;
                entity.teleportArtifact.location = location;
                entity.teleportArtifact.active = true;
            }

            if(!canUse) return;
            foreach (var entity in GetEntities<Camera>())
            {
                entity.transform.position = new float3(location.xy,entity.transform.position.z);
            }
        }
    }
}