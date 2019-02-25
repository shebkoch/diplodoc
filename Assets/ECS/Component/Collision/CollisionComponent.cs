using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Component
{
	public class CollisionComponent : MonoBehaviour
	{
		public int damage;
		public int receivedDamage;
		public CollisionType type;
		public List<CollisionType> receivedDamageFrom;

		private void OnTriggerEnter2D(Collider2D other)
		{
			var collisionComponent = other.GetComponent<CollisionComponent>();
			Collision(collisionComponent);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			var collisionComponent = other.gameObject.GetComponent<CollisionComponent>();
			Collision(collisionComponent);
		}

		private void Collision(CollisionComponent collisionComponent)
		{
			if (collisionComponent && IsDamageReceive(collisionComponent.type))
				receivedDamage += collisionComponent.damage;
		}

		private bool IsDamageReceive(CollisionType other)
		{
			return receivedDamageFrom.Contains(other);
		}
	}
	
	public enum CollisionType
	{
		Player,Enemy, PlayerAttack, Obstacle, Other
	}
}