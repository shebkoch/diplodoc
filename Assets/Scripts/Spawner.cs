using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
	public class Spawner : MonoBehaviour
	{
		public int radius;
		public Vector3 offset;
		public List<SpawnPair> prefabs;
		public void Start(){
			foreach (SpawnPair prefab in prefabs)
			{
				for (int i = 0; i < prefab.count; i++)
				{
					Instantiate(prefab.gameObject,offset+ Random.insideUnitSphere*radius,Quaternion.identity);
				}	
			}
		}
	}

	[System.Serializable]
	public struct SpawnPair
	{
		public GameObject gameObject;
		public int count;
	}
}