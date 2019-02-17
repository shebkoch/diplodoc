using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
	public class StunModificatorComponent : MonoBehaviour
	{
		public float duration;
		public bool isEnable;
		public float last;
		
		public Image indicator;
		public float fillAmount;
	}
}