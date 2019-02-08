using ECS.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.System
{
	public class EnemyDamageSystem : ComponentSystem
	{
		protected struct Enemy
		{
			public EnemyComponent enemyComponent;
			public DamageComponent damageComponent;
			public ParametersComponent parametersComponent;
		}

		protected override void OnUpdate()
		{
			foreach (Enemy entity in GetEntities<Enemy>())
			{
				bool isDamageDeal = entity.damageComponent.isDamageDeal;
				if (!isDamageDeal) continue;

				int health = entity.parametersComponent.health;
					
				health--;
					
				entity.parametersComponent.health = health;
				entity.damageComponent.isDamageDeal = false;
			}
		}


	}
}