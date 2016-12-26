using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour {

	[SerializeField]
	SpringPosition[] springs;
	[SerializeField]
	Vector3[] springsStart;
	[SerializeField]
	Vector3[] springsEnd;

	[SerializeField]
	float timer = 0.7f;

	void Start () {
		StartCoroutine (StartSprings ());
	}

	IEnumerator StartSprings ()
	{
		while (true)
		{
			for (int i = 0; i < springs.Length; i++) {
				springs[i].target = springsStart[i];
				springs[i].enabled = true;
			}

			yield return new WaitForSeconds(timer);

			for (int i = 0; i < springs.Length; i++) {
				springs[i].target = springsEnd[i];
				springs[i].enabled = true;
			}

			yield return new WaitForSeconds(timer);
		}
	}
}
