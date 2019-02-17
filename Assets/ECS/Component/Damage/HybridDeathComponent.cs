using Unity.Entities;
using UnityEngine;

namespace ECS.Component
{
	public class HybridDeathComponent : MonoBehaviour
	{
		public Entity entity;
		public float invokeTime = 0.1f;

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