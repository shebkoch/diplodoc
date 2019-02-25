using System.Collections.Generic;
using ECS.Component.Artifacts.Common;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
	public class UIShowArtifacts : MonoBehaviour
	{
		public List<Image> activeImages;
		public List<Image> passiveImages;

		private bool isActive = false;
		private void Update()
		{
			if(Input.anyKey) gameObject.SetActive(false);
			if (!isActive)
			{
				ArtifactsPoolComponent artifactsPoolComponent = FindObjectOfType<ArtifactsPoolComponent>();
				List<GameObject> active = artifactsPoolComponent.active;
				List<GameObject> passive = artifactsPoolComponent.passive;
				if(active == null || active.Count == 0) return;

				for (var i = 0; i < active.Count; i++)
				{
					activeImages[i].sprite = active[i].GetComponent<ArtifactComponent>().sprite;
				}
				for (var i = 0; i < passive.Count; i++)
				{
					passiveImages[i].sprite = passive[i].GetComponent<ArtifactComponent>().sprite;
				}
				isActive = true;
			}
		}
	}
}