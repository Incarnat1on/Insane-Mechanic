using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPoint : MonoBehaviour {
	[SerializeField]
	List <Collider> ObjectToFinish = new List<Collider>();

	void OnTriggerEnter ( Collider col)
	{
		if (ObjectToFinish.Any (x => x == col)) {
			ObjectToFinish.Remove (col);
			if (ObjectToFinish.Count == 0)
				PushTheButtoN.Instance.LevelComplete ();
		}
	}
}
