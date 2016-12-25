using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryContainer : MonoBehaviour {

	[SerializeField]
	ItemLogic ItemExample;

	List <ItemLevel> items = new List<ItemLevel> ();
	List <ItemLogic> itemSlots = new List<ItemLogic> ();

	public void AddItems (List <ItemLevel> _items)
	{
		items.Clear ();
		items.AddRange (_items);
		PrepareItems ();
	}


	void PrepareItems ()
	{
		foreach (var item in itemSlots) {
			Destroy (item);
		}

		for (int i = 0; i < items.Count; i++) 
		{
			var x = Instantiate (ItemExample, Vector3.zero, Quaternion.identity);
			x.transform.parent = ItemExample.transform.parent;
			x.transform.localScale = Vector3.one;
			x.transform.localPosition = new Vector3 (0, 0 - i * 150, 0);
			x.gameObject.SetActive (true);
			x.PrepareItem (items [i]);
			itemSlots.Add (x);
		}
	}
}
