using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts.Common
{
	public class ArtifactComponent : MonoBehaviour
	{
		public byte id;
		public Sprite sprite;
		public string artifactName;
		public string description;
	}
}