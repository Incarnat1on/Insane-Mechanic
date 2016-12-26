using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemLogic : MonoBehaviour
{
	[SerializeField]
	UI2DSprite _sprite;

	[SerializeField]
	UILabel count;
	int _count;

	List <GameObject> GameObj = new List <GameObject>();

	GameObject prefab;

	public int id;

	bool use;

	//Vector3 offset = new Vector3 (0, 0, 6.2f);

	public void PrepareItem(ItemLevel _it)
	{
		_sprite.sprite2D = _it.Icon;
		_count = _it.count;
		id = _it.id;
		prefab = _it.item;
		UpdateItem ();
	}

	public void Use()
	{
		
		if (_count <= 0) {
			this.gameObject.SetActive (false);
		}
		else 
		{
			_count -= 1;
			GameObj.Add(Instantiate (prefab, new Vector3(0,9999,0), prefab.transform.rotation));
			UpdateItem ();
		}
	}

	void OnPress(bool state)
	{ 
		if (state) 
		{
			Use ();
		} 
		else 
		{
			PushTheButtoN.Instance.itemSettings.SetItem(GameObj.FirstOrDefault ().transform,GameObj.FirstOrDefault ().GetComponent<ItemCall>());
			GameObj.Remove (GameObj.FirstOrDefault ());
		}
	}

	void OnDrag()
	{
		var t = GameObj.FirstOrDefault ().transform;
		t.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		t.position = new Vector3 (t.position.x, t.position.y, 0);
	}

	void UpdateItem ()
	{
		count.text = _count.ToString ();
	}

	IEnumerator MoveItem ()
	{
		while (use) {
			yield return new WaitForFixedUpdate();
		}
	}
}

