using ECS.System;
using ECS.System.Artifacts;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
	public class Boot : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKey(KeyCode.R))
			{
				SceneManager.LoadScene(0);
				World.Active.GetExistingManager<StartArtifactDistributionSystem>().Enabled = true;
				World.Active.GetExistingManager<LuckArtifactSystem>().Enabled = true;
			}
		}
	}
}