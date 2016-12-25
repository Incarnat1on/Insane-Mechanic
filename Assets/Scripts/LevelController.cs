using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour {
	[SerializeField]
	List <Rigidbody> ObjectsLevel = new List<Rigidbody>();

	List <Vector3> position = new List<Vector3> ();

	void Awake (){
		ActivatePhysic (true);

		//save start position
		position.AddRange(GetComponentsInChildren<Transform>().Where ( t=> t!=this.transform).Select(x => x.position));
		Debug.Log ("Level prepared");
		PushTheButtoN.Instance.InitLevel (this);
	}

	void ActivatePhysic (bool status = false) {
		for (int i = 0; i < ObjectsLevel.Count; i++) {
			ObjectsLevel [i].isKinematic = status;
		}

	}

	public void StateLevel (bool state)
	{
		if (state) {
			//FALSE Kinematic's
			ActivatePhysic ();
		} else {
			ActivatePhysic (true);
			ResetPosition ();
		}
	}

	private void ResetPosition (){
		for (int i = 0; i < ObjectsLevel.Count; i++) {
			ObjectsLevel [i].transform.position = position [i];

		}
	}

	public void AllComplete()
	{
		PushTheButtoN.Instance.LevelComplete ();
	}
}
