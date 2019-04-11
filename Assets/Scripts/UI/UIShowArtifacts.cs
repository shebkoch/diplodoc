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
		public List<Text> texts;
		public List<Image> passiveImages;

		private bool isActive = false;
		private void Update()
		{
//			Time.timeScale = 0.001f;
			if (Input.anyKey)
			{
				gameObject.SetActive(false);
//				Time.timeScale = 1;
			}
			if (!isActive)
			{
				ArtifactsPoolComponent artifactsPoolComponent = FindObjectOfType<ArtifactsPoolComponent>();
				List<GameObject> active = artifactsPoolComponent.active;
				List<GameObject> passive = artifactsPoolComponent.passive;
				if(active == null || active.Count == 0) return;

				for (var i = 0; i < active.Count; i++)
				{
					var artifactComponent = active[i].GetComponent<ArtifactComponent>();
					activeImages[i].sprite = artifactComponent.sprite;
					texts[i].text = artifactComponent.artifactName;
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