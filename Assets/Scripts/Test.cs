using UnityEngine;

namespace DefaultNamespace
{
	public class Test : MonoBehaviour
	{
		public int number;
		public int radius;
		public GameObject gameObject;
		public void Start(){
			for (int i = 0; i < number; i++)
			{
				Instantiate(gameObject, Random.insideUnitSphere*radius,Quaternion.identity);
			}	
		}
	}
}