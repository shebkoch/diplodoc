using ECS.Component.Stats;
using ECS.System.Stats;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Component.Artifacts
{
    public class AroundShotPassiveArtifact : MonoBehaviour
    {
        public GameObject bullet;
        public int2 bulletCount;
    }
}