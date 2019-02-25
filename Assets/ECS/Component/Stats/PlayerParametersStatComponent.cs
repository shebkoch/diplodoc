using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Stats
{
	public class PlayerParametersStatComponent : MonoBehaviour
	{
		public int lastHp;
		public int lastReceived;
	}
}