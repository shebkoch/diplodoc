using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace ECS.Component
{
	public class CollisionComponent : MonoBehaviour
	{
		public Dictionary<CollisionComponent, CollisionState> collisions =
			new Dictionary<CollisionComponent, CollisionState>();

		public List<CollisionComponent> enterList = new List<CollisionComponent>();
		public bool isEnable;

		public CollisionType receivedDamageFrom;
		public CollisionType type;

		//ecs
		private void AddToDictionary(Collider2D other, CollisionState state)
		{
			var collision = other.GetComponent<CollisionComponent>();
			if (!collision)
				throw new MissingComponentException(other.gameObject + " object must has collisionComponent");
			if (state == CollisionState.Exit)
				collisions.Remove(collision);
			else
				collisions.AddOrUpdate(collision, state);
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			AddToDictionary(other, CollisionState.Stay);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			AddToDictionary(other, CollisionState.Enter);
			enterList.Add(other.GetComponent<CollisionComponent>());
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			AddToDictionary(other, CollisionState.Exit);
		}
	}

	public enum CollisionState
	{
		Enter,
		Stay,
		Exit
	}

	public enum CollisionType
	{
		Enemy,
		PlayerAttack,
		Player,
		PickUp,
		Obstacle,
		EnemyAttack,
		None
	}
}