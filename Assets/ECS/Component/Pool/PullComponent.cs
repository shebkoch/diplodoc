using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Pool
{
	public class PullComponent : MonoBehaviour
	{
		public int countByTick;
		public List<GameObject> objects;
	}
}