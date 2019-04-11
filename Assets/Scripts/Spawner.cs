using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
	public class Spawner : MonoBehaviour
	{
		public Vector3 offset;
		public List<SpawnPair> prefabs;
		public int radius;
		public Image loadImage;
		public GameObject pressAnyMessage;
		public GameObject background;
		public int startPrefabCount;
		public int step = 0;
		public bool isActive = true;
		private void Start()
		{
			startPrefabCount = prefabs.Count;
			Time.timeScale = 0.0001f;
		}

		private void Update()
		{
			if(!isActive) return;

			if (prefabs.Count != 0)
			{
				var prefab = prefabs[0];
				step++;
				InstantiateOnePrefab(prefab);
				DrawLoading();
				prefabs.RemoveAt(0);
			}
			else
			{
				DrawMessage();
				if (Input.anyKey)
				{
					isActive = false;
					pressAnyMessage.SetActive(false);
					background.SetActive(false);
					Time.timeScale = 1f;
				}
			}
		}

		private void DrawMessage()
		{
			pressAnyMessage.SetActive(true);
			loadImage.gameObject.SetActive(false);
		}
		private void DrawLoading()
		{
			loadImage.fillAmount =  step / (float) startPrefabCount;
		}
		private void InstantiateOnePrefab(SpawnPair prefab)
		{
			for (var i = 0; i < prefab.count; i++)
			{
				Vector3 position = offset + Random.insideUnitSphere * radius;
				Instantiate(prefab.gameObject,position, Quaternion.identity,
					transform);
				var nested = prefab.gameObject.GetComponent<NestedObjects>();
				if (nested)
				{
					foreach (var nestedPosition in nested.positions)
					{
						Instantiate(nested.obj, position + nestedPosition.position, Quaternion.identity,
							transform);
					}
				}
			}

			//			for (var i = 0; i < prefab.count; i++)
//				Instantiate(prefab.gameObject, Rand.OnCircle(min, 0, radius) + offset, Quaternion.identity,transform);
		}
	}

	[Serializable]
	public struct SpawnPair
	{
		public GameObject gameObject;
		public int count;
	}
}