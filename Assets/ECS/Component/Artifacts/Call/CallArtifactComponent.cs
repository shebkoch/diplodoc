using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts.Call
{
	public class CallArtifactComponent : MonoBehaviour
	{
		public GameObject calling;
		public bool isCallNeeded;
		public int count;
		public float3 position;
	}
}