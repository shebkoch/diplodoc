using ECS.Component;
using ECS.Component.Artifacts;
using Unity.Entities;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System.Artifacts
{
	public class CooldownReduceSystem : ComponentSystem
	{
		protected struct Cooldown
		{
			public CooldownComponent cooldownComponent;
		}
		protected struct Artifact
		{
			public CooldownReduceArtifact cooldownReduceArtifact;
		}
		protected override void OnUpdate()
		{
			float percent = 0;
			foreach (Artifact entity in GetEntities<Artifact>())
			{
				percent = entity.cooldownReduceArtifact.percent;
			}

			foreach (var entity in GetEntities<Cooldown>())
			{
				entity.cooldownComponent.cooldown *= percent;
			}

			this.Enabled = false;
		}
	}
}