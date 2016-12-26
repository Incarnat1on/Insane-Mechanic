using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCall : MonoBehaviour {

	public bool active;
	void OnMouseDown()
	{
		if (!active)
		{
			PushTheButtoN.Instance.itemSettings.SetItem (this.transform, this);
		}
	}
}
