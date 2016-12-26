using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressed : MonoBehaviour {

	[SerializeField]
	ItemSettings IS;

	void OnPress (bool state) {
		if (!state) return;
		switch (gameObject.name) {
		case "Position":
			IS.StartPosition ();
			break;
		case "Rotation":
			IS.StartRotate ();
			break;
		case "Connect":
			Debug.Log ("connect fixedjoint");
			break;
		default :
			IS.End ();
			break;
	
		}
	}
}
