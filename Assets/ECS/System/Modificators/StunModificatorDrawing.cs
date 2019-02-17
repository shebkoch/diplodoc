using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
	public class StunModificatorDrawing : ComponentSystem
	{
		protected struct Modificator
		{
			public StunModificatorComponent stunModificatorComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Modificator entity in GetEntities<Modificator>())
			{
				entity.stunModificatorComponent.indicator.fillAmount = entity.stunModificatorComponent.fillAmount;
			}
		}
	}
}