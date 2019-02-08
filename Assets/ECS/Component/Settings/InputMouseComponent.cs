using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Component
{
    public class InputMouseComponent : MonoBehaviour
    {
        public float3 mousePosition;
        public MouseKeyState leftState;
        public MouseKeyState rightState;
        public float startHold = -1;
        public float holdTime = 0;
    }

    public enum MouseKeyState
    {
        Down, Up
    }
    
}