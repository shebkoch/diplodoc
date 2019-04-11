using System;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public static class Rand
{
	public static Random GetRandom()
	{
		return new Random((uint) DateTime.Now.Ticks);
	}

	public static float3 OnCircle(float3 radius, float min, float max)
	{
		float3 randomPos = new float3(UnityEngine.Random.insideUnitCircle.normalized, 0) * (radius + 
		                   UnityEngine.Random.Range(-min,max));
		return randomPos;
	}
}