using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts.Common
{
	public class ArtifactsPoolComponent : MonoBehaviour
	{
		public List<GameObject> activePool;
		public List<GameObject> passivePool;
		public int activeCount;
		public int passiveCount;
		public List<GameObject> active;
		public List<GameObject> passive;
	}
}