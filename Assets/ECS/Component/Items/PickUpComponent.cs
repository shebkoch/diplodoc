using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Items
{
	public class PickUpComponent : MonoBehaviour
	{
		public GameObject picker;

		//work only on player based on physic layer
		private void OnTriggerEnter2D(Collider2D other)
		{
			picker = other.gameObject;
		}
		
	}
}