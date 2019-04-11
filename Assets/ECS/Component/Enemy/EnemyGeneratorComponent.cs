using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Component.Enemy
{
	public class EnemyGeneratorComponent : MonoBehaviour
	{
		public int wave;
		public int breakAfter;
		public int wavePlus;
		public int spread;
		public List<SpawnPair> enemies;
	}
}
