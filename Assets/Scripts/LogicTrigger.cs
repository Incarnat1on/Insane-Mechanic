using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter ( Collider col )
	{
		if (col.tag == "box") {
			Debug.Log ("entered");
			col.GetComponent<Rigidbody> ().AddExplosionForce (25000, this.transform.position - new Vector3 (1, 0.1f, 0), 2);

		}

	}
}
