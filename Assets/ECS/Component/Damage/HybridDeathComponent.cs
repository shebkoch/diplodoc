using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component
{
	public class HybridDeathComponent : MonoBehaviour
	{
		public float invokeTime = 0.1f;
		public Entity entity;

		private void Start()
		{
			entity = GetComponent<GameObjectEntity>().Entity;
		}

		public void Death()
		{
			gameObject.SetActive(false);
		}

		public void DelayedDeath()
		{
			Invoke("Death", invokeTime);
		}
	}
}