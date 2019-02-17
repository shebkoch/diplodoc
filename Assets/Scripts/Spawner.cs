using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
	public class Spawner : MonoBehaviour
	{
		public Vector3 offset;
		public List<SpawnPair> prefabs;
		public int radius;

		public void Start()
		{
			foreach (var prefab in prefabs)
				for (var i = 0; i < prefab.count; i++)
					Instantiate(prefab.gameObject, offset + Random.insideUnitSphere * radius, Quaternion.identity);
		}
	}

	[Serializable]
	public struct SpawnPair
	{
		public GameObject gameObject;
		public int count;
	}
}